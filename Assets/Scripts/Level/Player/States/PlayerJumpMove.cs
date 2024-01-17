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
        }
    }

    public override void UpdateState()
    {
        if (controller.charCon.isGrounded)
        {
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

    }
}
