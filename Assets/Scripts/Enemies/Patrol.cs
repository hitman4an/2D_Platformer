using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Waypoint[] _waypoints;
    [SerializeField] float _patrolWait = 5f;
    
    private float _wait = 1f;
    private float _idleWait = 0;
    
    private Animator _animator;
    private DirectionChanger _directionChanger;

    private int _currentWaypoint = 0;
    private float _waypointDistanceRadius = 1f;
    private Vector3 _target;

    private MoveState _moveState = MoveState.Walk;
    private Coroutine _coroutine;

    private int Idle = Animator.StringToHash(nameof(Idle));
    private int Walk = Animator.StringToHash(nameof(Walk));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _directionChanger = GetComponent<DirectionChanger>();

        _target = _waypoints[_currentWaypoint].transform.position;
        _directionChanger.ChangeDirection(_target - transform.position);
    }

    private void Update()
    {
        if (_moveState == MoveState.Walk)
        {
            
            float distance = Vector3.Distance(transform.position, _target);

            _animator.Play(Walk);

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
        var wait = new WaitForSeconds(_wait);

        _moveState = MoveState.Idle;
        _animator.Play(Idle);

        while (_idleWait != _patrolWait)
        {
            _idleWait += _wait;
            
            yield return wait;
        }

        _idleWait = 0;
        _moveState = MoveState.Walk;
        _target = _waypoints[_currentWaypoint].transform.position;
        _directionChanger.ChangeDirection(_target - transform.position);

        yield return null;
    }

    enum MoveState
    {
        Idle,
        Walk        
    }
}
