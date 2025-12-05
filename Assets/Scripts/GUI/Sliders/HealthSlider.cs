using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthGUI
{
    private const float MaxValue = 1;    
    
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = MaxValue;
        _slider.maxValue = MaxValue;
    }
    
    public override void ChangeHealthValue(float newValue)
    {
        float sliderValue = newValue / Health.MaxHealth;
        
        if (sliderValue > _slider.maxValue)
        {
            _slider.value = _slider.maxValue;
        }

        _slider.value = sliderValue;

        if (sliderValue == 0)
        {
            _slider.gameObject.SetActive(false);
        }
    }
}
