using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerIdle
{
    public override void StartState()
    {
        if (controller.stateMachine.PreviousState.GetType() != typeof(PlayerJumpMove))
        {
            player.currentGravity = -controller.JumpHeight;
            player.animator.SetTrigger("StartJump");
            player.animator.SetBool("Jumping", true);
        }
    }

    public override void UpdateState()
    {
        if (controller.charCon.isGrounded)
        {
            player.animator.SetTrigger("Land");
            controller.stateMachine.ChangeState(typeof(PlayerIdle));
        }

        if (player.moveInput == Vector3.zero)
        {
            base.UpdateState();
        }
        else
        {
            controller.stateMachine.ChangeState(typeof(PlayerJumpMove));
        }
    }

    public override void ExitState()
    {
        player.animator.SetBool("Jumping", false);
        player.animator.SetBool("Running", false);
        player.animator.SetBool("Walking", false);
    }
}
