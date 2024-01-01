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
        // Slowly resetting the player's speed after coming out of the 'walk'/'run' state, so it doesn't instantly get set to 0
        if (player.moveInput == Vector3.zero)
        {
            if (player.moveAccel >= controller.Acceleration) { player.moveAccel -= controller.Acceleration; }
            else  {  player.moveAccel = 0; }

            controller.cc.Move((player.direction * player.moveAccel * Time.deltaTime) + player.movingPlatformSpeed);
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
