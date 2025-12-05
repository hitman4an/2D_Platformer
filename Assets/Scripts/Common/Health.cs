using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;

    public event Action<float> HealthChanged;
    public event Action CharacterHurt;
    public event Action CharacterDied;

    public int MaxHealth { get; private set; }

    private int _health;

    private Collector _collector;

    private void Awake()
    {
        MaxHealth = _maxHealth;
        _collector = GetComponent<Collector>();
    }

    private void OnEnable()
    {
        if (_collector)
            _collector.PotionTaken += TakePotion;
    }
    private void OnDisable()
    {
        if (_collector)
            _collector.PotionTaken -= TakePotion;
    }

    private void Start()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health -= damage, 0, MaxHealth);

        HealthChanged?.Invoke(_health);

        if (_health > 0)
        {
            CharacterHurt?.Invoke();
        }
        else
        {
            CharacterDied?.Invoke();
        }
    }

    public void Heal(int value)
    {
        if (value < 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health += value, 0, MaxHealth);

        HealthChanged?.Invoke(_health);
    }

    private void TakePotion(Potion potion)
    {
        if (_health != MaxHealth)
        {
            Heal(potion.HealValue);
            potion.Used();
        }
    }
}
