using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInputHandler;


public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    protected float xInputFloat;
    protected float yInputFloat;
    
    protected int mouseInputX;
    private bool dashInput;
    
    public PlayerGroundedState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    // public override void DoChecks()
    // {
    //     base.DoChecks();
    // }

    public override void Enter()
    {
        base.Enter();
        player.DashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.input.NormInputX;
        yInput = player.input.NormInputY;
        xInputFloat = player.input.MoveInputDir.x;
        yInputFloat = player.input.MoveInputDir.y;
        dashInput = player.input.DashInput;
        
        // mouseInputX = Mathf.FloorToInt(player.input.MousePos.x);

        if (player.input.AttackInputs[(int)CombatInputs.primary])
        {
            // player.CheckIfShouldFlipMousePos(mouseInputX);
            stateMachine.ChangeState(player.PrimaryAttack);
            PoolManager.Release(player.projectile, player.muzzle.position, player.muzzle.transform.rotation);
        }
        else if (dashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public Vector3 GetMoveDir() 
    {
        return player.input.MoveInputDir;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
