using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxValue = 100;

    public event Action<float> HealthChanged;
    public event Action CharacterHurt;
    public event Action CharacterDied;

    public float MaxValue { get; private set; }

    private float _value;

    private void Awake()
    {
        MaxValue = _maxValue;
    }

    private void Start()
    {
        _value = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            return;
        }

        _value = Mathf.Clamp(_value -= damage, 0, MaxValue);

        HealthChanged?.Invoke(_value);

        if (_value > 0)
        {
            CharacterHurt?.Invoke();
        }
        else
        {
            CharacterDied?.Invoke();
        }
    }

    public void Heal(float value)
    {
        if (value < 0)
        {
            return;
        }

        _value = Mathf.Clamp(_value += value, 0, MaxValue);

        HealthChanged?.Invoke(_value);
    }

    public void TakePotion(Potion potion)
    {
        if (_value != MaxValue)
        {
            Heal(potion.HealValue);
            potion.Used();
        }
    }
}
