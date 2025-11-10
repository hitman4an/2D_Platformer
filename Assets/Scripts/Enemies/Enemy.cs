using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 6f;
    [SerializeField] private float _chaserSpeed = 9f;
    [SerializeField] private EnemyGroundChecker _groundChecker;
    
    private Patrol _patrol;
    private EnemyMover _mover;
    private Chaser _chaser;    
    private ChaseTrigger _chaseTrigger;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _mover = GetComponent<EnemyMover>();
        _chaser = GetComponent<Chaser>();        
        _chaseTrigger = GetComponent<ChaseTrigger>();
    }

    private void OnEnable()
    {
        _chaseTrigger.OnPlayerSpotted += Chase;
        _chaseTrigger.OnPlayerGone += Patrol;
        _groundChecker.GroundEnded += Patrol;
    }
    private void OnDisable()
    {
        _chaseTrigger.OnPlayerSpotted -= Chase;
        _chaseTrigger.OnPlayerGone -= Patrol;
        _groundChecker.GroundEnded -= Patrol;
    }

    private void Start()
    {
        Patrol();
    }

    private void FixedUpdate()
    {
        _mover.Move();
        _patrol.CheckDestination();        
    }

    private void Chase()
    {
        _chaser.Chase(_chaserSpeed);
    }

    private void Patrol()
    {
        _patrol.StartPatrol(_patrolSpeed);
    }
}
