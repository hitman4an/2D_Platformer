using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _patrolWait = 5f;
    
    private EnemyMover _mover;

    private int _currentWaypoint = 0;
    private float _waypointDistanceRadius = 1f;    
    private Vector3 _target;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        checkDestination();
    }

    public void StartPatrol()
    {
        _target = _waypoints[_currentWaypoint].transform.position;
        _mover.GoToTarget(_target);
    }

    private void checkDestination()
    {
        float distance = (_target - transform.position).sqrMagnitude;

        if (distance < _waypointDistanceRadius)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            _target = _waypoints[_currentWaypoint].transform.position;
            _mover.Wait(_target, _patrolWait);
        }
    }
}
