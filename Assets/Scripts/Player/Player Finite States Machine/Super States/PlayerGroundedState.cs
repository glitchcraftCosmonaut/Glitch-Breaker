using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;


public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    protected int mouseInputX;
    
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
        mouseInputX = Mathf.FloorToInt(player.input.MousePos.x);

        if (player.input.AttackInputs[(int)CombatInputs.primary])
        {
            player.CheckIfShouldFlipMousePos(mouseInputX);
            stateMachine.ChangeState(player.PrimaryAttack);
        }
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
