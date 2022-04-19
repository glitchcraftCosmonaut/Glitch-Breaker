using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private InputActions playerInput;
    public PlayerInput input;
    private Rigidbody2D rb;
    Animator animator;
    [SerializeField] private float speed = 10f;
    bool facingRight = true;

    

    
    private void Awake() 
    {
        playerInput = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Start()
    {
        input.EnableGameplayInput();
    }
    
    private void Update() 
    {
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInput.Gameplay.MousePosition.ReadValue<Vector2>());
        // Debug.Log(input.MousePos);
        if (input.MousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }
        else if (input.MousePos.x < transform.position.x && facingRight)
        {
            flip();
        }
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
        rb.velocity = input.MoveInput * speed;
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
