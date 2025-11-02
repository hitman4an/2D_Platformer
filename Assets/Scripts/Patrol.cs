using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Waypoint[] _waypoints;
    [SerializeField] float _patrolWait = 5f;
    
    private float _wait = 1f;
    private float _idleWait = 0;
    
    private Animator _animator;    
    private int _currentWaypoint = 0;
    private float _waypointDistanceRadius = 2f;
    private MoveState _moveState = MoveState.Walk;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (_moveState == MoveState.Walk)
        {
            Vector3 target = _waypoints[_currentWaypoint].transform.position;
            Vector3 direction = (target - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, target);

            _animator.Play("Walk");

            if (distance < _waypointDistanceRadius)
            {
                _coroutine = StartCoroutine(Idle());
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;                
            }

            transform.rotation = direction.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(Vector3.zero);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Idle()
    {
        var wait = new WaitForSeconds(_wait);

        _moveState = MoveState.Idle;
        _animator.Play("Idle");

        while (_idleWait != _patrolWait)
        {
            _idleWait += _wait;
            
            yield return wait;
        }

        _idleWait = 0;
        _moveState = MoveState.Walk;

        yield return null;
    }

    enum MoveState
    {
        Idle,
        Walk        
    }
}
