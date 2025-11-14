using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;    
    [SerializeField] private PlayerAnimator _animator;    
    
    private Rigidbody2D _rigidBody;
    private Player _player;    
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();        
        _player = GetComponent<Player>();
    }

    public void Jump()
    {
        if (_player.IsGrounded)
        {
            _animator.SetSpeed(0);
            _rigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
