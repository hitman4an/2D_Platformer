using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimator : CharacterAnimator
{
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetGrounded(bool value)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, value);
    }

    public class PlayerAnimatorData: CharacterAnimatorData
    {
        new public class Params: CharacterAnimatorData.Params
        {
            public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        }
    }
}
