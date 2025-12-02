using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 6f;
    [SerializeField] private float _chaserSpeed = 9f;
    [SerializeField] private EnemyGroundChecker _groundChecker;
    [SerializeField] private ChaseTrigger _chaseTrigger;
    [SerializeField] private EnemyAnimator _animator;

    private Patrol _patrol;
    private EnemyMover _mover;
    private Chaser _chaser;    
    private Health _health;
    
    private CapsuleCollider2D _collider;
    private Rigidbody2D _rigidBody;
    private EnemyAttacker _attacker;

    private bool _isDead = false;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _mover = GetComponent<EnemyMover>();
        _chaser = GetComponent<Chaser>();                
        _health = GetComponent<Health>();        
        _collider = GetComponent<CapsuleCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<EnemyAttacker>();
    }

    private void OnEnable()
    {
        _chaseTrigger.OnPlayerSpotted += Chase;
        _chaseTrigger.OnPlayerGone += Patrol;
        _groundChecker.GroundEnded += Patrol;
        _health.CharacterDied += Die;
        _health.CharacterHurt += Hurt;
    }
    private void OnDisable()
    {
        _chaseTrigger.OnPlayerSpotted -= Chase;
        _chaseTrigger.OnPlayerGone -= Patrol;
        _groundChecker.GroundEnded -= Patrol;
        _health.CharacterDied -= Die;
        _health.CharacterHurt -= Hurt;
    }

    private void Start()
    {
        Patrol();
    }

    private void FixedUpdate()
    {
        if (_isDead == false)
        {
            _mover.Move();
            _patrol.CheckDestination();            
            _attacker.CheckAttackDistance();
        }
    }

    private void Chase(Player player)
    {
        if (_isDead == false)
            _chaser.Chase(player, _chaserSpeed);
    }

    private void Patrol()
    {
        if (_isDead == false)
            _patrol.StartPatrol(_patrolSpeed);
    }

    private void Hurt()
    {
        _animator.SetHurt();
    }

    private void Die()
    {
        _isDead = true;
        _animator.SetDead(true);
        _mover.StopMove();
                
        _rigidBody.bodyType = RigidbodyType2D.Static;
        _collider.enabled = false;
        this.enabled = false;
    }
}
