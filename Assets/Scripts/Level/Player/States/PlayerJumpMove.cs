using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerJumpMove : PlayerMove
{
    public override void StartState()
    {
        if (controller.stateMachine.PreviousState.GetType() != typeof(PlayerJump))
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
            controller.stateMachine.ChangeState(typeof(PlayerMove));
        }

        if (player.moveInput.magnitude > 0)
        {
            base.UpdateState();
        }
        else
        {
            controller.stateMachine.ChangeState(typeof(PlayerJump));
        }
    }

    public override void ExitState()
    {
        player.animator.SetBool("Jumping", false);
        player.animator.SetBool("Running", false);
        player.animator.SetBool("Walking", false);
    }
}
