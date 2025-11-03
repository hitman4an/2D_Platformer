using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    public void SetWalking(bool value)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsWalking, value);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
        }
    }
}
