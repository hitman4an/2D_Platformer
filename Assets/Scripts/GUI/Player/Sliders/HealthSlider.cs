using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthGUI
{
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = _health.MaxHealth;
        _slider.maxValue = _health.MaxHealth;
    }

    public override void ChangeHealthValue(float newValue)
    {
        if (newValue > _slider.maxValue)
        {
            _slider.value = _slider.maxValue;
        }

        _slider.value = newValue;
    }
}
