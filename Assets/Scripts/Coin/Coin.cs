using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private static readonly int Idle = CoinAnimator.PlayerAnimatorData.Params.Idle;
    private static readonly int Collect = CoinAnimator.PlayerAnimatorData.Params.Collect;

    [SerializeField] private float _respawnDelay = 5f;

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
        _coroutine = StartCoroutine(ShowWithDelay());
    }

    private IEnumerator ShowWithDelay()
    {
        yield return new WaitForSeconds(_respawnDelay);

        _animator.PlayAnimation(Idle);
        _collider.enabled = true;        
    }
}
