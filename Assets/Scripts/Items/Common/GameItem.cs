using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItem : MonoBehaviour
{
    public event Action<GameItem> ItemUsed;

    public void Used()
    {
        ItemUsed?.Invoke(this);
    }
}