using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    private const float CheckDelay = 0.1f;

    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _layer;

    public event Action<bool> OnGround;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Grounded());
    }
    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Grounded()
    {
        while (enabled)
        {
            var wait = new WaitForSeconds(CheckDelay);

            OnGround?.Invoke(Physics2D.OverlapCircle(transform.position, _checkRadius, _layer));

            yield return wait;
        }
    }

    private void Update()
    {
        Grounded();
    }
}
