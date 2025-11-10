using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    public void SetSpeed(float value)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.Speed, value);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        }
    }
}
