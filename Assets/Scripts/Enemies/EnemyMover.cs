using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;

    private RotationChanger _directionChanger;
        
    private Coroutine _coroutine;
    private Vector3 _target;
    private bool _isMoving;
    private float _speed;
    
    private void Awake()
    {
        _directionChanger = GetComponent<RotationChanger>();        
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Move()
    {
        if (_isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }
    }

    public void GoToTarget(Vector3 target, float speed)
    {
        _speed = speed;
        _animator.SetSpeed(_speed);
        _isMoving = true;
        _directionChanger.ChangeDirection(target - transform.position);
        _target = target;
    }

    public void Wait(Vector3 nextTarget, float patrolWait)
    {
        _animator.SetSpeed(0);
        _isMoving = false;
        _coroutine = StartCoroutine(StayBeforeNextTarget(nextTarget, patrolWait));
    }

    public void StopMove()
    {
        _isMoving = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator StayBeforeNextTarget(Vector3 nextTarget, float patrolWait)
    {
        var wait = new WaitForSeconds(patrolWait);

        yield return wait;

        GoToTarget(nextTarget, _speed);
    }
}
