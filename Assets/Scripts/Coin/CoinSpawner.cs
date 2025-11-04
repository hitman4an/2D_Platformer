using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void OnEnable()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        if ( _spawnPoints.Length > 0 )
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Coin coin = Instantiate(_prefab, spawnPoint.transform);
            }
        }
    }
}
