using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class CharacterAnimator : MonoBehaviour
{
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float value)
    {
        _animator.SetFloat(CharacterAnimatorData.Params.Speed, value);
    }

    public void SetAttack()
    {
        _animator.SetTrigger(CharacterAnimatorData.Params.Attack);
    }

    public void SetHurt()
    {
        _animator.SetTrigger(CharacterAnimatorData.Params.Hurt);
    }

    public class CharacterAnimatorData
    {
        public class Params
        {
            public static readonly int Speed = Animator.StringToHash(nameof(Speed));
            public static readonly int Attack = Animator.StringToHash(nameof(Attack));
            public static readonly int Hurt = Animator.StringToHash(nameof(Hurt));
        }
    }
}
