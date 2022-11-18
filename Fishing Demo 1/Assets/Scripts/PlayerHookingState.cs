using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookingState : PlayerBaseState
{
    private GameObject bobber;

    public override void EnterState(PlayerStateManager player)
    {
        bobber = player.GetComponent<PlayerStateManager>().currentBobber;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //If player presses space, we try to hook the fish
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If the bobber is sunk, it is a successful hit - enter the reeling state and set bobber to hooking
            if (bobber.GetComponent<Bobber>().sunk == true)
            {
                bobber.GetComponent<Bobber>().hooking = true;
                player.SwitchState(player.ReelingState);
            }
            else
            {
                UnityEngine.Object.Destroy(bobber);
                player.SwitchState(player.MovingState);
            }
        }
    }
}
