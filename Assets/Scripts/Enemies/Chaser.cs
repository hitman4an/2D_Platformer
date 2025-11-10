using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] Player _player;

    private EnemyAnimator _animator;
    private EnemyMover _mover;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
        _mover = GetComponent<EnemyMover>();
    }

    public void Chase(float speed)
    {
        _animator.SetSpeed(speed);
        _mover.GoToTarget(_player.transform.position, speed);
    }
}
