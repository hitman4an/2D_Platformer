using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.1f;

    public event Action<bool> IsGrounded;

    private int _playerCollidersCount = 1;

    private void Grounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _checkRadius);

        IsGrounded?.Invoke(colliders.Length > _playerCollidersCount);
    }

    private void Update()
    {
        Grounded();
    }
}
