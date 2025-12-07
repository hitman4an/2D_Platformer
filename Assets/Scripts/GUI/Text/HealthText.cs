using TMPro;
using UnityEngine;

public class HealthText: HealthGUI
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = $"{ Health.MaxValue}/{Health.MaxValue }";
    }

    public override void ChangeHealthValue(float newValue)
    {
        _text.text = $"{Mathf.RoundToInt(newValue)}/{Health.MaxValue}";
    }
}
