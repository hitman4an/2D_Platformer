using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private DirectionChanger _directionChanger;

    private MoveState _moveState;    
    private bool _isGrounded = true;

    public void Move(float axis)
    {
        Vector3 target = transform.position + Vector3.one * axis;
        Vector3 direction = target - transform.position;

        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Run;
            _animator.Play(PlayerAnimationData.Run);
        }
                
        _directionChanger.ChangeDirection(direction);
        _rigidBody.velocity = new Vector2(axis * _speed, _rigidBody.velocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse); 
            _moveState = MoveState.Jump;
            _animator.Play(PlayerAnimationData.Jump);
        }
    }

    public void StopMove()
    {
        if (_moveState != MoveState.Jump)
            Idle();
    }

    private void Idle()
    {
        _moveState = MoveState.Idle;
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        _animator.Play(PlayerAnimationData.Idle);
    }

    private void Awake() {
        
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();        
        _directionChanger = GetComponent<DirectionChanger>();
    }

    private void FixedUpdate()
    {
        IsGrounded();

        if (_isGrounded == false)
        {
            _animator.Play(PlayerAnimationData.Jump);
        }
        else if (_rigidBody.velocity.y == 0 && _moveState == MoveState.Jump)
        {
            Idle();
        }
    }

    private void IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.transform.position, _checkRadius);

        _isGrounded = colliders.Length > 1;
    }

    enum MoveState
    {
        Idle,
        Run,
        Jump
    }

    public static class PlayerAnimationData
    {
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
    }
}
