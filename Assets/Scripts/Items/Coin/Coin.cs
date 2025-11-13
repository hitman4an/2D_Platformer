using System;
using System.Collections;
using UnityEngine;

public class Coin : GameItem
{
    private static readonly int Collect = CoinAnimator.PlayerAnimatorData.Params.Collect;

    private CoinAnimator _animator;
    private Collider2D _collider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<CoinAnimator>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Take()
    {
        _collider.enabled = false;
        _animator.PlayAnimation(Collect);        
    }
}
