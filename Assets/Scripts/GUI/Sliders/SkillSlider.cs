using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlider : MonoBehaviour
{
    [SerializeField] VampireSkill _skill;
    [SerializeField] Canvas _canvas;

    private float _speed = 0.4f;
    
    private Coroutine _coroutine;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _slider.maxValue;
        _canvas.enabled = false;
    }

    private void OnEnable()
    {
        _skill.ChangeValue += OnValueChanged;
    }

    private void OnDisable()
    {
        _skill.ChangeValue -= OnValueChanged;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnValueChanged(float valueRate, bool isIncrease)
    {
        _coroutine = StartCoroutine(ChangeValue(valueRate, isIncrease));
    }

    private IEnumerator ChangeValue(float newValue, bool isIncrease)
    {
        float targetValue = isIncrease ? newValue : 1 - newValue;
        float startValue = _slider.value;
        float time = 0f;

        while (time <= _speed)
        {
            _slider.value = Mathf.Lerp(startValue, targetValue, time / _speed);

            yield return null;

            time += Time.deltaTime;
        }

        if (_slider.value == _slider.maxValue)
        {
            _canvas.enabled = false;
        }
        else
        {
            _canvas.enabled = true;
        }
    }
}
