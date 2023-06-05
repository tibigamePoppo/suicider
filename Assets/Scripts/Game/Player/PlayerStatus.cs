using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterBase
{
    public Action<bool> PlayerDead;
    PlayerAnimator PlayerAnimatoin;
    private void Start()
    {
        PlayerAnimatoin = GetComponent<PlayerAnimator>();
    }
    public override void dead()
    {
        Destroy(gameObject, 1.1f);
        PlayerAnimatoin.Dead();
        PlayerDead?.Invoke(true);
    }
}
