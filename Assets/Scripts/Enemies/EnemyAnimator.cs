using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    public void SetDead()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.IsDead);
    }

    public class EnemyAnimatorData: CharacterAnimatorData
    {
        new public class Params: CharacterAnimatorData.Params
        {
            public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
        }
    }
}
