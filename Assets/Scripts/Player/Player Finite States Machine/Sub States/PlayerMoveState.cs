using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private float nextSpawnDirtTime;
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
        if(!isAbilityDone)
        {
          
            // player.CheckIfShouldFlipMousePos(mouseInputX);
            // player.CheckIfShouldFlip(xInput);
            player.SetVelocityY(player.speed * yInputFloat);
            player.SetVelocityX(player.speed * xInputFloat);
            if (Time.time >= nextSpawnDirtTime) 
            {
                DirtParticleSystemHandler.Instance.SpawnDirt(player.GetPosition() + new Vector3(0, -0.52f), GetMoveDir() * -1f);
                nextSpawnDirtTime = Time.time + .08f;
            }
        }
        // if(!isAbilityDone)
        // {
        //     player.CheckIfShouldFlip(xInput);
        // }
        if (!isExitingState)
        {
            if (xInput == 0 && yInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
        
        

        // player.SetVelocityY(player.speed * yInput);
        // player.SetVelocityX(player.speed * xInput);
        // if (!isExitingState)
        // {
        //     if (xInput == 0 && yInput == 0)
        //     {
        //         stateMachine.ChangeState(player.IdleState);
        //     }
        // } 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        // player.SetVelocityX(player.speed * xInput);
        // player.SetVelocityY(player.speed * yInput);
    }

}
