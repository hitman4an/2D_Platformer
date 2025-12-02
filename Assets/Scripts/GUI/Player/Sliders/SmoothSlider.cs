using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlider : HealthSlider
{
    private float _maxDelta = 0.5f;

    private Coroutine _coroutine;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public override void ChangeHealthValue(float newValue)
    {
        if (newValue > _slider.maxValue)
        {
            _coroutine = StartCoroutine(ChangeValue(_slider.maxValue));            
        }

        _coroutine = StartCoroutine(ChangeValue(newValue));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _maxDelta);

            yield return null;
        }
    }
}
