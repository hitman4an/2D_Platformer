using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 0.4f;
    [SerializeField] private Transform _attackPoint;

    [SerializeField] private float _attackRadius = 5f;
    [SerializeField] private int _attackDamage = 50;

    [SerializeField] private LayerMask _opponentLayers;
    
    public event Action AttackFinished;

    private CharacterAnimator _animator;

    private bool _canAttack = true;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<CharacterAnimator>();
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

            Collider2D[] hitOpponents = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _opponentLayers);

            foreach (Collider2D opponent in hitOpponents)
            {
                Health health = opponent.GetComponent<Health>();

                if (health)
                {
                    opponent.GetComponent<Health>().TakeDamage(_attackDamage);
                }
            }

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

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint != null)
        {
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
        }
    }
}
