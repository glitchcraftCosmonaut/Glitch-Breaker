using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // mouseInputX = Mathf.FloorToInt(player.input.MousePos.x);

        player.CheckIfShouldFlip(xInput);
        // if(isAbilityDone)
        // {
        //     player.CheckIfShouldFlipMousePos(mouseInputX);
        // }
        // if(!isAbilityDone)
        // {
        //     player.CheckIfShouldFlip(xInput);
        // }
        
        

        player.SetVelocityY(player.speed * yInput);
        player.SetVelocityX(player.speed * xInput);
        if (!isExitingState)
        {
            if (xInput == 0 && yInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        } 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        // player.SetVelocityX(player.speed * xInput);
        // player.SetVelocityY(player.speed * yInput);
    }

}
