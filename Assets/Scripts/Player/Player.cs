using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    public bool IsAttack { get; private set; }
    public float Speed { get; private set; }
    

    [SerializeField] private GroundChecker _groundChecker;

    private PlayerAnimator _animator;    
    private PlayerMover _mover;
    private Jumper _jumper;
    private InputService _inputService;
    private PlayerAttacker _attacker;
       
    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _inputService = GetComponent<InputService>();
        _attacker = GetComponent<PlayerAttacker>();
    }
    private void OnEnable()
    {
        _groundChecker.Grounded += Grounded;
        _inputService.MovingBtnPressed += Move;
        _inputService.JumpBtnDown += Jump;
        _inputService.MovingBtnUp += StopMove;
        _inputService.AttackBtnPressed += Attack;
        _attacker.AttackFinished += FinishAttack;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= Grounded;
        _inputService.MovingBtnPressed -= Move;
        _inputService.JumpBtnDown -= Jump;
        _inputService.MovingBtnUp -= StopMove;
        _inputService.AttackBtnPressed -= Attack;
        _attacker.AttackFinished -= FinishAttack;
    }

    private void Update()
    {
        _inputService.GetInput();
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
    private void Move() 
    {
        _mover.Move();
    }

    private void Jump()
    {
        _jumper.Jump();
    }

    private void StopMove()
    {
        _mover.StopMove();
    }

    private void Attack()
    {
        if (IsGrounded && IsAttack == false)
        {
            if (Speed > 0)
                _mover.StopMove();

            IsAttack = true;
            _attacker.Attack();
        }
    }

    private void Grounded(bool value)
    {
        if (IsGrounded != value)
        {
            if (value)
            {
                _mover.StopMove();
            }

            IsGrounded = value;
            _animator.SetGrounded(value);
        }
    }

    private void FinishAttack()
    {
        IsAttack = false;
    }
}
