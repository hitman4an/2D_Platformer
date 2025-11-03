using System;
using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] float _respawnDelay = 5f;

    private Coin _coin;
    private Coroutine _coroutine;

    public void SetCoin(Coin coin)
    {
        _coin = coin;
        _coin.CoinCollected += RespawnCoin;
    }

    private void OnDisable()
    {
        if (_coin != null)
        {
            _coin.CoinCollected -= RespawnCoin;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void RespawnCoin()
    {
        _coin = null;
        _coroutine = StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        var wait = new WaitForSeconds(_respawnDelay);

        yield return wait;

        _coin = Instantiate(_prefab, transform);
        _coin.CoinCollected += RespawnCoin;
    }
}
