using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Potion> PotionTaken;
    
    private int _count = 0;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Take();
            _count++;
        }

        if (collider.TryGetComponent<Potion>(out Potion potion))
        {
            PotionTaken?.Invoke(potion);
        }
    }
}
