using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        Vector3 position = _player.position;

        position.z = -10f;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
