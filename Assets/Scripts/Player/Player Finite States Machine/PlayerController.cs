using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInputHandler;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    #region states

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState PrimaryAttack { get; private set; }
    public PlayerDashState DashState { get; private set;}

    #endregion

    #region setter getter
    
    public int FacingDirection {get; private set;}
    public Animator Anim { get; private set;}

    public float Angle {get; private set;}

    //velocity
    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    
    public Vector2 MovementStore  { get; private set; }
    public Vector2 MovementDirection  { get; private set; }

    #endregion
    
    #region Player Data
    // private InputActions playerInput;
    [HideInInspector] public PlayerInputHandler input;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float attackDash = 10f;
    [SerializeField] public float dashSpeed = 10f;
    [SerializeField] public float dashCooldown = 2f;
    [SerializeField] public float dashTime = 0.2f;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform muzzle;
    [SerializeField] public Transform muzzleChild;
    public float drag = 10f;

    private Vector3 targetPos;

    #endregion

    [HideInInspector] public Rigidbody2D playerRB;
    

    
    private void Awake() 
    {
        // playerInput = new InputActions();
        input = GetComponent<PlayerInputHandler>();
        playerRB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        FacingDirection = 1;
        CanSetVelocity = true;

        #region statemachine
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState (this, StateMachine, "Move");
        PrimaryAttack = new PlayerAttackState (this, StateMachine, "Attack");
        DashState = new PlayerDashState (this, StateMachine, "Dash");
        #endregion
    }
    private void OnEnable()
    {
        // playerInput.Enable();
        // input.onAttack += Attack;
    }
    private void OnDisable()
    {
        // playerInput.Disable();
        // input.onAttack -= Attack;

    }
    private void Start()
    {
        input.EnableGameplayInput();
        StateMachine.Initialize(IdleState);
    }
    
    private void Update() 
    {
        AimAndShoot();
        
        MovementStore = MovementDirection;
        MovementDirection = input.MoveInput;
        CurrentVelocity = playerRB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        // PoolManager.Release(projectile, muzzle.position, Quaternion.identity);

 
        // }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        // playerRB.velocity = input.MoveInput * speed;
   
        // Anim.SetFloat("Speed", input.MoveInput.sqrMagnitude);
    }
    public void CheckIfShouldFlipMousePos(int mouseInputX)
    {
        if (mouseInputX > transform.position.x && FacingDirection == -1)
        {
            Flip();
        }
        else if (mouseInputX < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput !=FacingDirection)
        {
            Flip();
        }
    }
     public void SetVelocityZero()
    {
        workspace = Vector2.zero;        
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 angle, float direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        SetFinalVelocity();
    }
    public void SetVelocityXY(float velocityX, float velocityY)
    {
        workspace.Set(velocityX, velocityY);
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            playerRB.velocity = workspace;
            CurrentVelocity = workspace;
        }        
    }

    public void Flip()
    {
        FacingDirection *= -1;
        playerRB.transform.Rotate(0.0f, 180f, 0.0f);
        // facingRight = !facingRight;
        // transform.Rotate(0f, 180f, 0f);
    }

    private void AimAndShoot()
    {
        // Vector3 aim = new Vector3(0f, 0f, Mathf.Atan2(input.MoveInput.y, input.MoveInput.x) * Mathf.Rad2Deg);
        // Vector3 aim = new Vector3(Mathf.Abs(input.MoveInput.x), input.MoveInput.y, 0f);
        Vector3 aim = new Vector3(input.MoveInput.x, input.MoveInput.y, 0f);
        if(input.MoveInput.magnitude > 0.01f)
        {
            Angle = Mathf.Atan2(input.MoveInput.y, input.MoveInput.x) * Mathf.Rad2Deg;
            // muzzle.transform.rotation = Quaternion.Lerp (muzzle.transform.rotation, Quaternion.Euler 
            //     (new Vector3 (0, 0, Angle)), Time.deltaTime * 10);
            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0f,0f, Angle));
            // muzzle.transform.position = 
            //     RotatePointAroundPivot(muzzle.transform.position,
            //                 transform.position,
            //                 Quaternion.Euler(new Vector3(0f,0f, Angle)));
            // muzzle.transform.RotateAround(transform.position, aim, 2 * Time.deltaTime);
        }
        // if(aim.magnitude > 0.1f)
        // {
        //     aim.Normalize();
        //     aim *= 0.4f;
        //     muzzle.transform.localPosition = aim;
        //     // transform.localPosition = aim;
        // }
    }
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * ( point - pivot) + pivot;
    }
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void AnimationTurnOnFlipTigger() => StateMachine.CurrentState.AnimationTurnOnFlipTigger();
    private void AnimationTurnOffFlipTigger() => StateMachine.CurrentState.AnimationTurnOffFlipTrigger();
    private void AnimationStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
    private void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();
}
