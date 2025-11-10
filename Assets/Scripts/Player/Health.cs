using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private Collector _collector;

    private int _health;

    private void Awake()
    {
        _collector = GetComponent<Collector>();
    }

    private void OnEnable()
    {
        _collector.PotionTaken += Heal;
        _health = _maxHealth - 1;
    }
    private void OnDisable()
    {
        _collector.PotionTaken -= Heal;
    }

    private void Heal(Potion potion)
    {
        if (_health == _maxHealth)
        {
            return;
        }
        
        _health += potion.HealValue;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        potion.Used();
    }
}
