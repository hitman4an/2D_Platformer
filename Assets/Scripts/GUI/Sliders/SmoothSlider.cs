using System.Collections;
using UnityEngine;

public class SmoothSlider : HealthSlider
{
    private float _speed = 0.5f;

    private Coroutine _coroutine;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public override void ChangeHealthValue(float newValue)
    {
        if (newValue == 0)
        {
            _slider.gameObject.SetActive(false);
            return;
        }
        
        float sliderValue = newValue / Health.MaxValue;

        _coroutine = StartCoroutine(ChangeValue(Mathf.Clamp(sliderValue, _slider.minValue, _slider.maxValue)));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        float startValue = _slider.value;
        float time = 0f;

        while (time <= _speed)
        {
            _slider.value = Mathf.Lerp(startValue, targetValue, time / _speed);

            yield return null;

            time += Time.deltaTime;
        }
    }
}
