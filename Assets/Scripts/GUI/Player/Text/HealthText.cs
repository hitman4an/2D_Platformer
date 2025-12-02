using TMPro;

public class HealthText : HealthGUI
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = $"{ _health.MaxHealth}/{ _health.MaxHealth }";
    }

    public override void ChangeHealthValue(float newValue)
    {
        _text.text = $"{newValue}/{_health.MaxHealth}";
    }
}
