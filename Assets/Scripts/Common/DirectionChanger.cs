using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    public void ChangeDirection(Vector3 direction)
    {
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
