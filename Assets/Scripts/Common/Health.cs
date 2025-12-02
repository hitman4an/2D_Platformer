using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;

    public event Action CharacterDied;
    public event Action CharacterHurt;
    public event Action<float> HealthChanged;

    public int MaxHealth { get; private set; }

    private int _health;
    private Collector _collector;

    private void Awake()
    {
        _collector = GetComponent<Collector>();
        MaxHealth = _maxHealth;
    }

    private void OnEnable()
    {
        if (_collector != null)
        {
            _collector.PotionTaken += Heal;
        }
    }

    private void OnDisable()
    {
        if (_collector != null)
        {
            _collector.PotionTaken -= Heal;
        }
    }

    private void Start()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        CharacterHurt?.Invoke();

        if (_health <= 0)
        {
            _health = 0;
            CharacterDied?.Invoke();
        }

        HealthChanged?.Invoke(_health);
    }

    public void Heal(Potion potion)
    {
        if (_health == MaxHealth)
        {
            return;
        }

        _health += potion.HealValue;

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        HealthChanged?.Invoke(_health);
        potion.Used();
    }

    public void Heal(int value)
    {
        if (_health == MaxHealth)
        {
            return;
        }

        _health += value;

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        HealthChanged?.Invoke(_health);
    }
}
