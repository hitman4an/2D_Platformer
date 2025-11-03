using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = other.GetComponent<Coin>();
        
        if (coin != null)
        {
            coin.Take();
            _count++;
        }
    } 
}
