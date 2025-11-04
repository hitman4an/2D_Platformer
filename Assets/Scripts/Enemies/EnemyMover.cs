using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private DirectionChanger _directionChanger;
    private EnemyAnimator _animator;

    private Coroutine _coroutine;
    private Vector3 _target;
    private bool _isMoving;
    
    private void Awake()
    {
        _directionChanger = GetComponent<DirectionChanger>();
        _animator = GetComponent<EnemyAnimator>();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime);
        }
    }

    public void GoToTarget(Vector3 target)
    {
        _animator.SetWalking(true);
        _isMoving = true;
        _directionChanger.ChangeDirection(target - transform.position);
        _target = target;
    }

    public void Wait(Vector3 nextTarget, float patrolWait)
    {
        _animator.SetWalking(false);
        _isMoving = false;
        _coroutine = StartCoroutine(StayBeforeNextTarget(nextTarget, patrolWait));
    }

    private IEnumerator StayBeforeNextTarget(Vector3 nextTarget, float patrolWait)
    {
        var wait = new WaitForSeconds(patrolWait);

        yield return wait;

        GoToTarget(nextTarget);
    }
}
