using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected float _attackCooldown = 0.4f;
    [SerializeField] protected Transform _attackPoint;

    [SerializeField] protected float _attackRadius = 5f;
    [SerializeField] protected int _attackDamage = 50;

    [SerializeField] protected LayerMask _opponentLayer;
    [SerializeField] protected AnimationEvents _animationEvents;

    protected CharacterAnimator _animator;

    protected bool _canAttack = true;
    protected Coroutine _coroutine;

    protected virtual void Awake()
    {
        _animator = _animationEvents.GetComponent<CharacterAnimator>();
    }

    private void OnEnable()
    {
        _animationEvents.FinishAttack += FinishAttack;
        _animationEvents.CommitDamage += CommitDamage;
    }

    private void OnDisable()
    {
        _animationEvents.FinishAttack -= FinishAttack;
        _animationEvents.CommitDamage -= CommitDamage;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint != null)
        {
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
        }
    }

    public abstract void Attack();
    public abstract void CommitDamage();

    protected IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackCooldown);

        _canAttack = true;        
    }

    private void FinishAttack()
    {
        _coroutine = StartCoroutine(AttackCooldown());
    }
}
