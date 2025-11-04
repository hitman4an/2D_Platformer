using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private InputService _inputService;    

    private PlayerAnimator _animator;
    private DirectionChanger _directionChanger;
    private Rigidbody2D _rigidBody;
    private Player _player;
        
    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _directionChanger = GetComponent<DirectionChanger>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _inputService.MovingBtnPressed += Move;
        _inputService.MovingBtnUp += StopMove;        
    }

    private void OnDisable()
    {
        _inputService.MovingBtnPressed -= Move;
        _inputService.MovingBtnUp -= StopMove;        
    }

    public void Move()
    {
        float axis = Input.GetAxis(Horizontal);
        Vector3 target = transform.position + Vector3.one * axis;
        Vector3 direction = target - transform.position;

        if (_player.IsGrounded)
        {
            _animator.SetSpeed(_speed);
        }

        _directionChanger.ChangeDirection(direction);
        _rigidBody.velocity = new Vector2(axis * _speed, _rigidBody.velocity.y);
    }
    
    public void StopMove()
    {
        _animator.SetSpeed(0);
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }
}
