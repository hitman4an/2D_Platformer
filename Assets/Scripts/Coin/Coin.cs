using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string CollectName = "Collect";
    private const string IdleName = "Idle";
    private const float RespawnDelay = 5f;
    
    private readonly int Collect = Animator.StringToHash(CollectName);
    private readonly int Idle = Animator.StringToHash(IdleName);

    private Animator _animator;
    private Collider2D _collider;

    private Coroutine _coroutine;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
        _animator.Play(Collect);
        _coroutine = StartCoroutine(ShowWithDelay());
    }

    private IEnumerator ShowWithDelay()
    {
        yield return new WaitForSeconds(RespawnDelay);

        _animator.Play(Idle);
        _collider.enabled = true;        
    }
}
