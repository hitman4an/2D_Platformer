using TMPro;

public class HealthText: HealthGUI
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _text.text = $"{ Health.MaxHealth}/{Health.MaxHealth }";
    }

    public override void ChangeHealthValue(float newValue)
    {
        _text.text = $"{newValue}/{Health.MaxHealth}";
    }
}
