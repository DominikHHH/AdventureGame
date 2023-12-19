using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerState
{
    public override void StartState()
    {
        
    }

    public override void UpdateState()
    {
        if (player.moveInput.magnitude > 0)
        {
            float max_speed = (player.runInput ? controller.RunSpeed : controller.WalkSpeed);
            player.moveAccel += controller.Acceleration;
            player.moveAccel = Mathf.Clamp(player.moveAccel, 0, max_speed);

            controller.cc.Move(player.direction * player.moveAccel * Time.deltaTime);
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
