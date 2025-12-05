using UnityEngine;

public abstract class HealthGUI : MonoBehaviour
{
    [SerializeField] public Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += ChangeHealthValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= ChangeHealthValue;
    }

    public abstract void ChangeHealthValue(float newValue);
}
