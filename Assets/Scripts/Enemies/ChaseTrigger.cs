using System;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public event Action OnPlayerSpotted;
    public event Action OnPlayerGone;

    private void OnTriggerEnter2D(Collider2D collider)
    {
         if (collider.TryGetComponent<Player>(out _))
        {
            OnPlayerSpotted?.Invoke();
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
