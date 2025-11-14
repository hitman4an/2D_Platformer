using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action CommitDamage;    
    public event Action FinishAttack;

    public void InvokeCommitDamageEvent() => CommitDamage?.Invoke();
    public void InvokeFinishAttackEvent() => FinishAttack?.Invoke();    
}
