using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : Attacker
{
    private EnemyMover _mover;
    private Health _target;

    public override void Attack()
    {
        _canAttack = false;

        _mover.StopMove();
        _animator.SetSpeed(0);
        _animator.SetAttack();
    }

    public void CheckAttackDistance()
    {
        if (_canAttack)
        {
            Collider2D[] hitOpponents = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _opponentLayer);

            foreach (Collider2D opponent in hitOpponents)
            {
                _target = opponent.GetComponent<Health>();

                if (_target != null)
                {
                    Attack();
                }
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _mover = GetComponent<EnemyMover>();
    }

    protected override void CommitDamage()
    {
        if (_target != null)
        {
            _target.TakeDamage(_attackDamage);
        }
    }
}
