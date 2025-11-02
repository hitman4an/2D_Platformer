using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Coin _prefab;
    [SerializeField] float _respawnDelay = 5f;

    private SpawnPoint[] _spawnPoints;
    private List<Coroutine> _coroutines = new List<Coroutine>();   


    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void OnEnable()
    {
        if (_spawnPoints.Length > 0)
        {
            foreach (SpawnPoint point in _spawnPoints)
            {
                point.CoinTaken += RespawnCoin;
            }

            SpawnCoins();
        }
    }

    private void OnDisable()
    {
        if (_spawnPoints.Length > 0)
        {
            foreach (SpawnPoint point in _spawnPoints)
            {
                point.CoinTaken -= RespawnCoin;
            }
        }
        
        if (_coroutines.Count > 0)
        {
            foreach (Coroutine coroutine in _coroutines)
            {
                StopCoroutine(coroutine);
            }
        }
    }

    private void SpawnCoins()
    {
        if ( _spawnPoints.Length > 0 )
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Coin obj = Instantiate(_prefab, spawnPoint.transform);
                spawnPoint.SetCoin(obj);
            }
        }
    }

    private void RespawnCoin(SpawnPoint spawnPoint)
    {
        _coroutines.Add(StartCoroutine(SpawnWithDelay(spawnPoint)));
    }

    private IEnumerator SpawnWithDelay(SpawnPoint spawnPoint)
    {
        var wait = new WaitForSeconds(_respawnDelay);

        yield return wait;

        Coin obj = Instantiate(_prefab, spawnPoint.transform);
        spawnPoint.SetCoin(obj);
    }
}
