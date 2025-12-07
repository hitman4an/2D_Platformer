using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _count = 0;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Take();
            _count++;
        }

        if (collider.TryGetComponent<Potion>(out Potion potion))
        {
            _health.TakePotion(potion);
        }
    }
}
