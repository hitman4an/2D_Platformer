using System;
using System.Collections.Specialized;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action CoinCollected;

    private const string Collect = "Collect";

    private Animator _animator;
    private Collider2D _collider;

    private int _collect = Animator.StringToHash(Collect);

    public void Take() 
    {
        _collider.enabled = false;
        _animator.Play(_collect);
        CoinCollected?.Invoke();
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();        
    }
    
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
