using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 0.4f;

    public event Action AttackFinished;

    private PlayerAnimator _animator;    

    private bool _canAttack = true;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();                
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Attack()
    {
        if (_canAttack)
        {
            _animator.SetAttack();
            _canAttack = false;
            _coroutine = StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackCooldown);

        _canAttack = true;
    }

    private void FinishPlayerAttack()
    {
        AttackFinished?.Invoke();
    }
}
