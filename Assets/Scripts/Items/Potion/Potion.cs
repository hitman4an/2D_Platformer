using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : GameItem
{
    [SerializeField] private int _healValue = 20;

    public int HealValue { get; private set; }

    private void OnEnable()
    {
        HealValue = _healValue;
    }
}
