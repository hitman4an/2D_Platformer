using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player _player;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
        
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            _player.Move();
         
        if (Input.GetButtonDown("Jump"))
            _player.Jump();
          
        if (Input.GetButtonUp("Horizontal"))
            _player.StopMove();        
    }
}
