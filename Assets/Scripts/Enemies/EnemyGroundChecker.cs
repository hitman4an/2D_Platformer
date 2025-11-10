using System;
using UnityEngine;
using UnityEngine.Tilemaps;


public class EnemyGroundChecker : MonoBehaviour
{
    public event Action GroundEnded;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TilemapCollider2D>(out _))
        {
            GroundEnded?.Invoke();
        }
    }
}
