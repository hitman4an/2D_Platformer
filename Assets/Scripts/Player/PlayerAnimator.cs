using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    public void SetGrounded(bool value)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, value);
    }
    public void SetSpeed(float value)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.Speed, value);
    }

    public void SetAttack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);        
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
            public static readonly int Speed = Animator.StringToHash(nameof(Speed));
            public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        }
    }
}
