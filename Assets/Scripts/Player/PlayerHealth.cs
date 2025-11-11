using System;
using UnityEngine;

public class PlayerHealth : Health
{
     private Collector _collector;    

    private void Awake()
    {
        _collector = GetComponent<Collector>();        
    }

    private void OnEnable()
    {
        _collector.PotionTaken += Heal;
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
