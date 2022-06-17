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
        player.CheckIfShouldFlip(xInput);
        
        

        // player.SetVelocityY(player.speed * yInput);
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
