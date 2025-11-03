using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action<float> MovingBtnPressed;
    public event Action MovingBtnUp;
    public event Action JumpBtnDown;

    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    private void Update()
    {
        if (Input.GetButton(Horizontal))
            MovingBtnPressed?.Invoke(Input.GetAxis(Horizontal));

        if (Input.GetButtonDown(Jump))
            JumpBtnDown?.Invoke();

        if (Input.GetButtonUp(Horizontal))
            MovingBtnUp?.Invoke();
    }
}
