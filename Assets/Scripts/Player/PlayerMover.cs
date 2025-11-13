using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _speed;      

    private PlayerAnimator _animator;
    private RotationChanger _directionChanger;
    private Rigidbody2D _rigidBody;
    private Player _player;
        
    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _directionChanger = GetComponent<RotationChanger>();
        _player = GetComponent<Player>();
    }

    public void Move()
    {
        if (_player.IsGrounded)
        {
            float axis = Input.GetAxis(Horizontal);
            Vector3 target = transform.position + Vector3.one * axis;
            Vector3 direction = target - transform.position;

            _directionChanger.ChangeDirection(direction);
            _rigidBody.velocity = new Vector2(axis * _speed, _rigidBody.velocity.y);

            _animator.SetSpeed(_speed);
            _player.SetSpeed(_speed);
        }
    }
    
    public void StopMove()
    {
        _animator.SetSpeed(0);
        _player.SetSpeed(0);
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }
}
