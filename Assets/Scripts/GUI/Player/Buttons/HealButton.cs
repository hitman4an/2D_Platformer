using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : ButtonClickEvent
{
    private const int HealValue = 10;

    [SerializeField] protected Health _health;

    public override void HandleClick()
    {
        _health.Heal(HealValue);
    }
}
