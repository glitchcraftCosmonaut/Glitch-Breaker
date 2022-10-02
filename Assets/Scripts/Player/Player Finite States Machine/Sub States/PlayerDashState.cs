using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }

    public Vector2 DashDirection {get; private set;}
    public Vector2 DashDirectionInput {get; private set;}


    private float lastDashTime;

    private float velocityToSet;

    // private bool setVelocity;
    private bool shouldCheckFlip;


    public PlayerDashState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanDash = false;
        player.input.UseDashInput();
        DashDirection = player.muzzleChild.position - player.transform.position;
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
        // DashDirectionInput = player.input.MoveInput;
        // attackCounter++;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // dashDirectionInput = player.input.DashDirectionInput;
        // DashDirection = DashDirectionInput;
        // DashDirection = DashDirectionInput;
        // DashDirectionInput = player.input.MoveInput;
        if(!isExitingState)
        {
            DashDirectionInput = player.input.MoveInput;
            if(DashDirectionInput != Vector2.zero)
            {
                // player.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                DashDirection = DashDirectionInput;
                DashDirection.Normalize();
                player.SetVelocity(velocityToSet, DashDirection);
                player.playerRB.drag = player.drag; //Player rigid body using local drag variable
                lastDashTime = Time.time; //to determine last time when the player using dash
            }
            else
            {
                DashDirection.Normalize();
                player.SetVelocity(velocityToSet, DashDirection);
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
        player.SetVelocity(velocity, DashDirection);
        velocityToSet = velocity;
        // setVelocity = true;
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

    public Vector2 DashFacingDirection()
    {
        return DashDirectionInput = DashDirection;
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
