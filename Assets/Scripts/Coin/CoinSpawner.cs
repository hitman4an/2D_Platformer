using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        if ( _spawnPoints.Length > 0 )
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Coin coin = Instantiate(_prefab, spawnPoint.transform);
                spawnPoint.SetCoin(coin);
            }
        }
    }
}
