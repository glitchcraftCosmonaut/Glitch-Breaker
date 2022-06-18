using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public int amountOfAttacks { get; protected set; }
    public float movementSpeed { get; protected set; }
    private int xInput;
    protected int mouseInputX;

    private Vector2 attackDirection;
    private Vector2 attackDirectionInput; 

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;

    protected int attackCounter;

    protected Vector3 targetPos;


    public PlayerAttackState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }



    public override void Enter()
    {
        base.Enter();
        setVelocity = false;
        attackDirection = Vector2.right * player.FacingDirection;
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
        attackDirectionInput = player.input.AttackDirectionInput;
        if(attackDirectionInput != Vector2.zero)
        {
            attackDirection = attackDirectionInput;
            attackDirection.Normalize();
            player.CheckIfShouldFlip(Mathf.RoundToInt(attackDirection.x));
            player.playerRB.drag = player.drag;
            player.SetVelocity(player.attackDash, attackDirection);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
    public void SetPlayerVelocity(float velocity)
    {
        velocityToSet = velocity;
        setVelocity = true;
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
    

    public override void AnimationStartMovementTrigger()
    {
        SetPlayerVelocity(player.attackDash);
    }

    public override void AnimationStopMovementTrigger()
    {
        SetPlayerVelocity(0f);
    }
}
