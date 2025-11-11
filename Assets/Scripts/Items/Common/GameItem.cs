using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItem : MonoBehaviour
{
    public event Action<GameItem, float> ItemUsed;

    public void Used(float delay = 0)
    {
        ItemUsed?.Invoke(this, delay);
    }
}