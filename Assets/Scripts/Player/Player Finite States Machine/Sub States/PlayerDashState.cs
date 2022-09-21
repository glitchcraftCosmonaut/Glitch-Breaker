using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    private float lastDashTime;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;
    private bool dashInputStop;


    public PlayerDashState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanDash = false;
        player.input.UseDashInput();
        dashDirectionInput = player.input.DashDirectionInput;
        dashDirection = dashDirectionInput;
        setVelocity = false;
        // dashDirection = Vector2.right * player.FacingDirection;
        // if(attackCounter >= amountOfAttacks)
        // {
        //     attackCounter = 0;
        // }
        // player.Anim.SetBool("Dash",true);
        // player.Anim.SetInteger("AttackCounter", attackCounter);
       
    }

    public override void Exit()
    {
        base.Exit();
        // player.Anim.SetBool("Attack", false);
        // attackCounter++;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // dashDirectionInput = player.input.DashDirectionInput;
        if(!isExitingState)
        {
            if(dashDirectionInput != Vector2.zero || setVelocity)
            {
                // dashDirection = dashDirectionInput;
                dashDirection.Normalize();// This value is to determine the flip so it using normalize vector
                player.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                player.SetVelocity(player.dashSpeed, dashDirectionInput);
                player.playerRB.drag = player.drag; //Player rigid body using local drag variable
                lastDashTime = Time.time; //to determine last time when the player using dash
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //Add this animation event at the start of the frame of this animation
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    //Set the velocity workspace of the player according to dash speed varriable. state not gonna work if this method empty or not used
    public void SetPlayerVelocity(float velocity)
    {
        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    //Add this to animation event on dash animation in the end of the frame
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
    
    //Add this to animation event on dash animation at the start of the frame
    public override void AnimationStartMovementTrigger()
    {
        SetPlayerVelocity(player.dashSpeed);
    }

    //Add this to animation event on dash animation in the end of the frame
    public override void AnimationStopMovementTrigger()
    {
        SetPlayerVelocity(0f);
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + player.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;

    // public override void AnimationStartMovementTrigger()
    // {
    //     SetPlayerVelocity(player.dashSpeed);
    // }

    // public override void AnimationStopMovementTrigger()
    // {
    //     SetPlayerVelocity(0f);
    // }
}
