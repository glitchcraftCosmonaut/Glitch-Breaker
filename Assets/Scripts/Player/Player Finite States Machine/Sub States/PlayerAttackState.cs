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

    // private bool setVelocity;
    private bool shouldCheckFlip;

    protected int attackCounter;

    protected Vector3 targetPos;


    public PlayerAttackState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }



    public override void Enter()
    {
        base.Enter();
        player.input.UsePrimaryAttackInput();
        attackDirection = player.muzzleChild.position - player.transform.position;

        // setVelocity = false;
        // attackDirection = Vector2.right * player.FacingDirection;
        if(attackCounter >= amountOfAttacks)
        {
            attackCounter = 0;
        }
        // player.Anim.SetBool("Attack",true);
        player.Anim.SetInteger("AttackCounter", attackCounter);
       
    }

    public override void Exit()
    {
        base.Exit();
        // player.Anim.SetBool("Attack", false);
        attackCounter++;
        // for future update using counter and reset attack when player already reach 3 attack combo and cooldown on certain time
        // also do continuous combo on certain time so when player doesn't click attack button continuous the counter will reset
        if(attackCounter <= 3)
        {
            attackCounter = 0;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        if(!isExitingState)
        {
                if (Time.time >= nextSpawnDirtTime) 
            {
                DirtParticleSystemHandler.Instance.SpawnDirt(player.GetPosition() + new Vector3(0, -0.52f), GetMoveDir() * -1f);
                nextSpawnDirtTime = Time.time + .08f;
            }
            attackDirectionInput = player.input.MoveInput;
            // attackDirectionInput = player.input.AttackDirectionInput;
            if(attackDirectionInput != Vector2.zero)
            {
                attackDirection = attackDirectionInput;
                attackDirection.Normalize();
                player.SetVelocity(velocityToSet, attackDirection);
                player.playerRB.drag = player.drag;
            }
            else
            {
                player.SetVelocity(velocityToSet, attackDirection);
                player.playerRB.drag = player.drag;
            }
        }
    }
    public Vector3 GetMoveDir() 
    {
        return attackDirection;
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
        player.SetVelocity(velocity, attackDirection);
        velocityToSet = velocity;
        // setVelocity = true;
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
