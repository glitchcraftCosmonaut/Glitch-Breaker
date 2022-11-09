using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInputHandler;
using UnityEngine.InputSystem;


public class PlayerController : Character
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

    #endregion
    
    #region Player Data
    // private InputActions playerInput;
    [SerializeField] Statsbar_HUD statsbar_HUD;
    [SerializeField] bool regenerateHealth = true;
    [SerializeField] float healthRegenerateTime;
    [SerializeField,Range(0f, 1f)] float healthRegeneratePercent;


    [SerializeField] public PlayerInputHandler input;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float attackDash = 10f;
    [SerializeField] public float dashSpeed = 10f;
    [SerializeField] public float dashCooldown = 2f;
    [SerializeField] public float dashTime = 0.2f;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform muzzle;
    [SerializeField] public Transform muzzleChild;
    [SerializeField] public GameObject dashAfterImage;
    [SerializeField] public float distBetweenAfterImages = 0.5f;

    public AudioData slashSFX;
    [HideInInspector] public Rigidbody2D playerRB;
    // new Collider2D collider;
    public float drag = 10f;

    private Vector3 targetPos;

    // readonly float InvincibleTime = 1f;

    WaitForSeconds waitHealthRegenerateTime;
    // WaitForSeconds waitInvincibleTime;

    Coroutine healthRegenerateCoroutine;

    #endregion

    

    
    private void Awake() 
    {
        // playerInput = new InputActions();
        // input = GetComponent<PlayerInputHandler>();
        playerRB = GetComponent<Rigidbody2D>();
        // collider = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        defaultMat2D = GetComponent<SpriteRenderer>().material;
        FacingDirection = 1;
        CanSetVelocity = true;

        #region statemachine
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState (this, StateMachine, "Move");
        PrimaryAttack = new PlayerAttackState (this, StateMachine, "Attack");
        DashState = new PlayerDashState (this, StateMachine, "Dash");
        #endregion

        waitHealthRegenerateTime = new WaitForSeconds(healthRegenerateTime);
        // waitInvincibleTime = new WaitForSeconds(InvincibleTime);
    }
    protected override void OnEnable()
    {
        // playerInput.Enable();
        // input.onAttack += Attack;
        base.OnEnable();
        sp.material = defaultMat2D;
    }
    // private void OnDisable()
    // {
    //     // playerInput.Disable();
    //     // input.onAttack -= Attack;

    // }
    private void Start()
    {
        statsbar_HUD.Initialize(health,maxHealth);
        input.EnableGameplayInput();
        StateMachine.Initialize(IdleState);
    }
    
    private void Update() 
    {
        AimAndShoot();
        
        CurrentVelocity = playerRB.velocity;
        StateMachine.CurrentState.LogicUpdate();
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
    }

    private void AimAndShoot()
    {
        Vector3 aim = new Vector3(input.MoveInput.x, input.MoveInput.y, 0f);
        if(input.MoveInput.magnitude > 0.01f)
        {
            Angle = Mathf.Atan2(input.MoveInput.y, input.MoveInput.x) * Mathf.Rad2Deg;
            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0f,0f, Angle));
        }
    }

    public override void RestoreHealth(float value)
    {
        base.RestoreHealth(value);
        statsbar_HUD.UpdateStates(health, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        // StartCoroutine(HurtEffect());
        base.TakeDamage(damage);
        CinemachineShake.Instance.ShakeCamera(2f, 0.1f);
        TimeController.Instance.Stop(0.1f);
        // PowerDown();
        statsbar_HUD.UpdateStates(health, maxHealth);
        statsbar_HUD.animator.SetTrigger("TakeDamage");
        // TimeController.Instance.BulletTime(slowMotionDuration);
        if(gameObject.activeSelf)
        {
            // Move(moveDirection);
            // StartCoroutine(InvincibleCoroutine());
            if(regenerateHealth)
            {
                if(healthRegenerateCoroutine != null)
                {
                    StopCoroutine(healthRegenerateCoroutine);
                }
                healthRegenerateCoroutine = StartCoroutine(HealthRegenerationCoroutine(waitHealthRegenerateTime, healthRegeneratePercent));
            }
        }
    }

    // IEnumerator InvincibleCoroutine()
    // {
    //     collider.isTrigger = true;

    //     yield return waitInvincibleTime;

    //     collider.isTrigger = false;
    // }
    public override void Die()
    {
        GameManager.onGameOver?.Invoke();
        GameManager.GameState = GameState.GameOver;
        statsbar_HUD.UpdateStates(0f, maxHealth);
        // StopCoroutine(HurtEffect());
        base.Die();
    }
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void AnimationTurnOnFlipTigger() => StateMachine.CurrentState.AnimationTurnOnFlipTigger();
    private void AnimationTurnOffFlipTigger() => StateMachine.CurrentState.AnimationTurnOffFlipTrigger();
    private void AnimationStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
    private void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();
}
