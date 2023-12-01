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
            if (controller.rb.velocity.sqrMagnitude <= max_speed)
            {
                Vector3 direction = controller.cam.transform.TransformDirection(controller.player.inputMove);
                direction.y = 0;
                controller.rb.AddForce(direction * controller.Acceleration, ForceMode.VelocityChange);
            }
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
