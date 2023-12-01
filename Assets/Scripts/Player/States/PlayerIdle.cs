using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{
    public override void StartState()
    {
        Debug.Log("Player is idle! Yay!");
    }

    public override void UpdateState()
    {
        if (controller.player.inputMove.magnitude <= 0)
        {
            //Debug.Log("Idle");
        }
        else
        {
            controller.stateMachine.ChangeState(typeof(PlayerMove));
        }
    }

    public override void ExitState()
    {
        
    }
}
