using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;


public class VampireSkill : MonoBehaviour
{
    [SerializeField] private float _activeTime = 6.0f;
    [SerializeField] private float _cooldown = 4.0f;
    [SerializeField] private float _drainRate = 5.0f;
    [SerializeField] private Health _player;
    [SerializeField] private LayerMask _enemyMask;

    public event Action<float, bool> ChangeValue;

    private bool _canActivate = true;
    private bool _isActive = false;

    private Coroutine _coroutine;
    private Health _enemy;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();        
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine); 
    }

    private void Update()
    {
        if (_isActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Abs(_sprite.bounds.extents.x), _enemyMask);

            _enemy = hit ? hit.collider.gameObject.GetComponent<Health>() : null;
        }
    }

    public void Activate()
    {
        if (_canActivate)
        {
            _isActive = true;
            _canActivate = false;
            _sprite.enabled = true;            
            _coroutine = StartCoroutine(Work());
        }
    }

    private IEnumerator Work()
    {
        float time = 1f;
        
        while (time <= _activeTime + 1)
        {
            ChangeValue?.Invoke(time / _activeTime, false);

            if (_enemy)
            {
                _enemy.TakeDamage(_drainRate * Time.deltaTime);
                _player.Heal(_drainRate * Time.deltaTime);
            }

            yield return null;

            time += Time.deltaTime;
        }
        
        _sprite.enabled = false;
        _isActive = false;
        _coroutine = StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float time = 1f;

        while (time <= _cooldown + 1)
        {
            ChangeValue?.Invoke(time / _cooldown, true);

            yield return null;

            time += Time.deltaTime;
        }

        _canActivate = true;
    }

}
