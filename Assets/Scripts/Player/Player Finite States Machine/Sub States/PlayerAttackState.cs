using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public int amountOfAttacks { get; protected set; }
    public float[] movementSpeed { get; protected set; }
    private int xInput;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;

    protected int attackCounter;

    public PlayerAttackState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }



    public override void Enter()
    {
        base.Enter();
        setVelocity = false;
        if(attackCounter >= amountOfAttacks)
        {
            attackCounter = 0;
        }
        player.Anim.SetBool("Attack",true);
        player.Anim.SetInteger("AttackCounter", attackCounter);
       
    }

    public override void Exit()
    {
        base.Exit();
        player.Anim.SetBool("Attack", false);
        attackCounter++;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
    }

    public override void AnimationTurnOffFlipTrigger()
    {
        SetFlipCheck(false);
    }

    public override void AnimationTurnOnFlipTigger()
    {
        SetFlipCheck(true);
    }
    

    // public virtual void AnimationStartMovementTrigger()
    // {
    //     SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    // }

    // public virtual void AnimationStopMovementTrigger()
    // {
    //     SetPlayerVelocity(0f);
    // }
}
