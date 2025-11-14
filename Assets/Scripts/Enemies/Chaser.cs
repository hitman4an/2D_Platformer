using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void Chase(Player player, float speed)
    {
        _animator.SetSpeed(speed);
        _mover.GoToTarget(player.transform.position, speed);
    }
}
