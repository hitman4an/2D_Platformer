using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Patrol _patrol;
    
    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void Start()
    {
        Patrol();
    }

    private void Patrol()
    {
        _patrol.StartPatrol();
    }
}
