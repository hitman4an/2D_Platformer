using System;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public event Action<Player> OnPlayerSpotted;
    public event Action OnPlayerGone;

    private void OnTriggerEnter2D(Collider2D collider)
    {
         if (collider.TryGetComponent<Player>(out Player player))
        {
            OnPlayerSpotted?.Invoke(player);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out _))
        {
            OnPlayerGone?.Invoke();
        }
    }
}
