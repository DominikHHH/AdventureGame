using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{
    public override void StartState()
    {
        
    }

    public override void UpdateState()
    {
        if (player.moveInput == Vector3.zero)
        {
            if (player.moveAccel >= controller.Acceleration)
            {
                player.moveAccel -= controller.Acceleration;
                controller.cc.Move(player.direction * player.moveAccel * Time.deltaTime);
            }
            else { player.moveAccel = 0; }
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
