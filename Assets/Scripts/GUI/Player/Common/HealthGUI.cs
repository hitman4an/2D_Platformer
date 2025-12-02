using UnityEngine;

public abstract class HealthGUI : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += ChangeHealthValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeHealthValue;
    }

    public abstract void ChangeHealthValue(float newValue);
}
