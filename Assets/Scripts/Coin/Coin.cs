using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action CoinCollected;    

    private Animator _animator;
    private Collider2D _collider;

    private int Collect = Animator.StringToHash(nameof(Collect));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _collider.enabled = false;
            _animator.Play(Collect);
            CoinCollected?.Invoke();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
