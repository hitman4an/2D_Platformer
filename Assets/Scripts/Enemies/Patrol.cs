using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _patrolWait = 5f;
    
    private DirectionChanger _directionChanger;
    private EnemyAnimator _animator;

    private int _currentWaypoint = 0;
    private float _waypointDistanceRadius = 1f;
    private bool _isMoving = true;
    private Vector3 _target;

    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
        _directionChanger = GetComponent<DirectionChanger>();

        _target = _waypoints[_currentWaypoint].transform.position;
        _directionChanger.ChangeDirection(_target - transform.position);
        _animator.SetWalking(true);
    }

    private void Update()
    {
        if (_isMoving)
        {
            float distance = (_target - transform.position).sqrMagnitude;

            if (distance < _waypointDistanceRadius)
            {
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
                _coroutine = StartCoroutine(Wait());
            }

            transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null) 
            StopCoroutine(_coroutine);
    }

    private IEnumerator Wait()
    {
        var wait = new WaitForSeconds(_patrolWait);

        _isMoving = false;
        _animator.SetWalking(false);

        yield return wait;

        _isMoving = true;
        _animator.SetWalking(true);
        _target = _waypoints[_currentWaypoint].transform.position;
        _directionChanger.ChangeDirection(_target - transform.position);
    }
    
}
