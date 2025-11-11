using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth = 100;

    public event Action CharacterDied;
    public event Action CharacterHurt;

    protected int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            CharacterHurt?.Invoke();
            CharacterDied?.Invoke();
        }
        else
        {
            CharacterHurt?.Invoke();
        }
    }
}
