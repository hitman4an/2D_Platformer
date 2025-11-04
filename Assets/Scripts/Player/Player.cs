using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    [SerializeField] private GroundChecker _groundChecker;

    private PlayerAnimator _animator;    

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
    }
    private void OnEnable()
    {
        _groundChecker.OnGround += onGround;
    }

    private void OnDisable()
    {
        _groundChecker.OnGround -= onGround;
    }

    private void onGround(bool value)
    {
        IsGrounded = value;
        _animator.SetGrounded(value);
    }
}
