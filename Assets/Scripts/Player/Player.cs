using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private InputService _inputService;

    private Rigidbody2D _rigidBody;    
    private DirectionChanger _directionChanger;    
    private GroundChecker _groundChecker;
    private PlayerAnimator _animator;

    private bool _isGrounded = true;

    private void Awake() {
        _animator = GetComponent<PlayerAnimator>();
        _rigidBody = GetComponent<Rigidbody2D>();        
        _directionChanger = GetComponent<DirectionChanger>();        
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        _inputService.MovingBtnPressed += Move;
        _inputService.JumpBtnDown += Jump;
        _inputService.MovingBtnUp += StopMove;
        _groundChecker.OnGround += IsGrounded;
    }

    private void OnDisable()
    {
        _inputService.MovingBtnPressed -= Move;
        _inputService.JumpBtnDown -= Jump;
        _inputService.MovingBtnUp -= StopMove;
        _groundChecker.OnGround -= IsGrounded;
    }

    private void Move(float axis)
    {
        Vector3 target = transform.position + Vector3.one * axis;
        Vector3 direction = target - transform.position;

        if (_isGrounded)
        {
            _animator.SetSpeed(_speed);
        }

        _directionChanger.ChangeDirection(direction);
        _rigidBody.velocity = new Vector2(axis * _speed, _rigidBody.velocity.y);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _animator.SetSpeed(0);
            _rigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void StopMove()
    {
        _animator.SetSpeed(0);
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }

    private void IsGrounded(bool value)
    {
        _isGrounded = value; 
        _animator.SetGrounded(value);
    }
}
