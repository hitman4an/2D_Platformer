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

    public void StartPatrol(float speed)
    {
        if (_waypoints.Length > 0)
        {
            _target = _waypoints[_currentWaypoint].transform.position;
            _mover.GoToTarget(_target, speed);
        }
    }

    public void CheckDestination()
    {
        float distance = (_target - transform.position).sqrMagnitude;

        if (distance < _waypointDistanceRadius && _waypoints.Length > 0)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            _target = _waypoints[_currentWaypoint].transform.position;
            _mover.Wait(_target, _patrolWait);
        }
    }
}
