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

    public event Action<bool> Grounded;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(CheckGrounded());
    }
    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator CheckGrounded()
    {
        while (enabled)
        {
            var wait = new WaitForSeconds(CheckDelay);

            Grounded?.Invoke(Physics2D.OverlapCircle(transform.position, _checkRadius, _layer));

            yield return wait;
        }
    }
}
