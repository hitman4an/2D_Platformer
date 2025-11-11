using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    public void SetDead(bool value)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsDead, value);
    }

    public class EnemyAnimatorData: CharacterAnimatorData
    {
        new public class Params: CharacterAnimatorData.Params
        {
            public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
        }
    }
}
