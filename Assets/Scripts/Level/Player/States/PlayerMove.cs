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
            // First, calculate the max speed the player can reach, determined by whether they are walking or running
            float max_speed = (player.runInput ? controller.RunSpeed : controller.WalkSpeed);
            player.moveAccel += controller.Acceleration;
            player.moveAccel = Mathf.Clamp(player.moveAccel, 0, max_speed);

            // Then, rotate the player in their current movement
            transform.LookAt(transform.position + player.direction, Vector3.up);

            controller.cc.Move((transform.forward * player.moveAccel * Time.deltaTime) + player.movingPlatformSpeed);
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
