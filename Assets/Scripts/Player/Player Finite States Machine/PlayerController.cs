using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    #region states

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState PrimaryAttack { get; private set; }

    #endregion

    #region setter getter
    
    public int FacingDirection {get; private set;}
    public Animator Anim { get; private set;}

    //velocity
    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;


    #endregion
    
    #region Player Data
    // private InputActions playerInput;
    [SerializeField] public PlayerInput input;
    [SerializeField] public float speed = 10f;
    [SerializeField] private float attackDash = 10f;
    private Vector3 targetPos;

    #endregion


    protected int xInput;
    private Rigidbody2D playerRB;
    

    
    private void Awake() 
    {
        // playerInput = new InputActions();
        playerRB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        FacingDirection = 1;

        #region statemachine
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState (this, StateMachine, "Move");
        PrimaryAttack = new PlayerAttackState (this, StateMachine, "Attack");
        #endregion
    }
    private void OnEnable()
    {
        // playerInput.Enable();
        input.onAttack += Attack;
    }
    private void OnDisable()
    {
        // playerInput.Disable();
        input.onAttack -= Attack;

    }
    private void Start()
    {
        input.EnableGameplayInput();
        StateMachine.Initialize(IdleState);
    }
    
    private void Update() 
    {
        CurrentVelocity = playerRB.velocity;
        StateMachine.CurrentState.LogicUpdate();
 
        // }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        playerRB.velocity = input.MoveInput * speed;
   
        // Anim.SetFloat("Speed", input.MoveInput.sqrMagnitude);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput !=FacingDirection)
        {
            Flip();
        }
    }
    public void Flip()
    {
        FacingDirection *= -1;
        playerRB.transform.Rotate(0.0f, 180f, 0.0f);
        // facingRight = !facingRight;
        // transform.Rotate(0f, 180f, 0f);
    }
    // FIX THIS K
    void Attack()
    {
        targetPos = new Vector3(input.MousePos.x, input.MousePos.y, 0);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, attackDash * 1 * Time.deltaTime);
        Anim.SetTrigger("AttackDash"); //bug here mf
        if (input.MousePos.x > transform.position.x && FacingDirection == -1)
        {
            Flip();
        }
        else if (input.MousePos.x < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }
    }
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
