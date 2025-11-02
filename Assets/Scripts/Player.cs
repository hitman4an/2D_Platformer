using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidBody;
    private Animator _animator;    
    private MoveState _moveState;
    private SpriteRenderer _sprite;
    private bool _isGrounded = true;

    public void Move()
    {
        Vector2 direction = transform.right * Input.GetAxis("Horizontal");

        _sprite.flipX = direction.x < 0;        

        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Run;
            _animator.Play("Run");
        }

        _rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidBody.velocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            Vector2 direction = (transform.right * Input.GetAxis("Horizontal")).normalized;            

            _rigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse); 
            _moveState = MoveState.Jump;
            _animator.Play("Jump");
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
        _animator.Play("Idle");
    }

    private void Awake() {
        
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        IsGrounded();

        if (_isGrounded == false)
        {
            _animator.Play("Jump");
        }
        else if (_rigidBody.velocity.y == 0 && _moveState == MoveState.Jump)
        {
            Idle();
        }
    }

    private void IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.transform.position, _checkRadius);

        _isGrounded = colliders.Length > 2;
    }

    enum MoveState
    {
        Idle,
        Run,
        Jump
    }
}
