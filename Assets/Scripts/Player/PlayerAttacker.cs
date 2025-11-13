using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerAttacker : Attacker
{
    public override void Attack()
    {
        _canAttack = false;
        _animator.SetAttack();
    }

    protected override void CommitDamage()
    {
        Collider2D[] hitOpponents = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _opponentLayer);

        foreach (Collider2D opponent in hitOpponents)
        {
            Health health = opponent.GetComponent<Health>();

            if (health)
            {
                opponent.GetComponent<Health>().TakeDamage(_attackDamage);
            }
        }        
    }
}
