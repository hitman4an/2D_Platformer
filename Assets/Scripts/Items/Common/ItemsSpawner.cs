using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameItem[] _prefabs;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private List<GameItem> _ourItems = new List<GameItem>();
    
    private void OnEnable()
    {
        SpawnItems();
    }

    public void ItemUsed(GameItem item)
    {
        if (_ourItems.Contains(item))
        {
            _ourItems.Remove(item);
            item.ItemUsed -= ItemUsed;
        }

        Destroy(item.gameObject);
    }

    private void SpawnItems()
    {
        if (_spawnPoints.Length > 0)
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                GameItem obj = Instantiate(GetPrefab(), spawnPoint.transform);
                obj.ItemUsed += ItemUsed;
                _ourItems.Add(obj);
            }
        }
    }

    private GameItem GetPrefab()
    {
        int index = Random.Range(0, _prefabs.Length);

        return _prefabs[index];
    }
}
