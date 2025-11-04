using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    private Animator _animator;

    public void PlayAnimation(int animationHash)
    {
        _animator.Play(animationHash);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int Idle = Animator.StringToHash(nameof(Idle));
            public static readonly int Collect = Animator.StringToHash(nameof(Collect));
        }
    }
}
