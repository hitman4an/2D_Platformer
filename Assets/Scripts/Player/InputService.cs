using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Attack = "Fire1";

    public event Action MovingBtnPressed;
    public event Action MovingBtnUp;
    public event Action JumpBtnDown;
    public event Action AttackBtnPressed;

    public void GetInput()
    {
        if (Input.GetButton(Horizontal))
            MovingBtnPressed?.Invoke();

        if (Input.GetButtonDown(Jump))
            JumpBtnDown?.Invoke();

        if (Input.GetButtonUp(Horizontal))
            MovingBtnUp?.Invoke();

        if (Input.GetButton(Attack))
        {
            AttackBtnPressed?.Invoke();
        }
    }
}
