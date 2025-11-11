using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimator : CharacterAnimator
{
      public void SetGrounded(bool value)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, value);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public class PlayerAnimatorData: CharacterAnimatorData
    {
        new public class Params: CharacterAnimatorData.Params
        {
            public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        }
    }
}
