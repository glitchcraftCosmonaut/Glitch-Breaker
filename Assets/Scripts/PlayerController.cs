using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public int FacingDirection {get; private set;}
    private InputActions playerInput;
    protected int xInput;
    public PlayerInput input;
    private Rigidbody2D playerRB;
    Animator animator;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float attackDash = 10f;
    private Vector3 targetPos;
    bool facingRight = true;

    

    
    private void Awake() 
    {
        playerInput = new InputActions();
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        FacingDirection = 1;
    }
    private void OnEnable()
    {
        playerInput.Enable();
        input.onAttack += Attack;
    }
    private void OnDisable()
    {
        playerInput.Disable();
        input.onAttack -= Attack;

    }
    private void Start()
    {
        input.EnableGameplayInput();
    }
    
    private void Update() 
    {
        xInput = input.NormInputX;
        CheckIfShouldFlip(xInput);
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInput.Gameplay.MousePosition.ReadValue<Vector2>());
        // Debug.Log(input.MousePos);
        // if (input.MousePos.x > transform.position.x && !facingRight)
        // {
        //     Flip();
        // }
        // else if (input.MousePos.x < transform.position.x && facingRight)
        // {
        //     Flip();
        // }
        // if(playerInput.currentControlScheme == "Keyboard") // this one not working i dunno
        // {
        // }
    }

    private void FixedUpdate()
    {
        // Vector2 moveInput = playerInput.Gameplay.Movement.ReadValue<Vector2>();
        // Debug.Log(input.MoveInput);
        // animator.SetFloat("Horizontal", moveInput.x);
        // animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", input.MoveInput.sqrMagnitude);
        playerRB.velocity = input.MoveInput * speed;
    }
    void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput !=FacingDirection)
        {
            Flip();
        }
    }
    void Flip()
    {
        FacingDirection *= -1;
        playerRB.transform.Rotate(0.0f, 180f, 0.0f);
        // facingRight = !facingRight;
        // transform.Rotate(0f, 180f, 0f);
    }
    void Attack()
    {
        targetPos = new Vector3(input.MousePos.x, input.MousePos.y, 0);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, attackDash * 1 * Time.deltaTime);
        animator.SetTrigger("AttackDash"); //bug here mf
        if (input.MousePos.x > transform.position.x && FacingDirection == -1)
        {
            Flip();
        }
        else if (input.MousePos.x < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }
    }
}
