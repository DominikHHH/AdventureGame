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
        if (controller.player.inputMove.magnitude > 0)
        {
            float max_speed = (controller.player.inputRun ? controller.RunSpeed : controller.WalkSpeed);
            Vector3 direction = controller.cam.transform.TransformDirection(controller.player.inputMove);
            direction.y = 0;

            controller.cc.Move(direction * max_speed);
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
