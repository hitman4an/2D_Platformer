using System;
using UnityEditor;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public event Action<SpawnPoint> CoinTaken;

    private Coin _coin;

    public void SetCoin(Coin coin)
    {
        _coin = coin;
        _coin.CoinCollected += CoinCollected;
    }

    private void OnDisable()
    {
        if (_coin != null)
        {
            _coin.CoinCollected -= CoinCollected;
        }
    }

    private void CoinCollected()
    {
        CoinTaken?.Invoke(this);
    }
}
