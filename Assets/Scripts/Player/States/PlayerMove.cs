using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerState
{
    public override void StartState()
    {
        Debug.Log("Player is moving! Yay!");
    }

    public override void UpdateState()
    {
        if (controller.player.inputMove.magnitude > 0)
        {
            controller.rb.AddForce(controller.player.inputMove * (controller.player.inputRun ? controller.RunSpeed : controller.WalkSpeed));
        }
        else
        {
            controller.stateMachine.ChangeState(typeof(PlayerIdle));
        }
    }

    public override void ExitState()
    {

    }
}
