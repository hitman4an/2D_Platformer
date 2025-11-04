using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private Quaternion _rightRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion _leftRotation = new Quaternion(0, 180, 0, 0);

    public void ChangeDirection(Vector3 direction)
    {
        if (direction.x < 0)
        {
            transform.rotation = _leftRotation;
        }
        else if (direction.x > 0)
        {
            transform.rotation = _rightRotation;
        }
    }
}
