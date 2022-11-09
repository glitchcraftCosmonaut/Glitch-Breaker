using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    public Rigidbody2D RB2D {get; private set;}
    [SerializeField]
    public Transform muzzleChild;

    [SerializeField]
    private float maxSpeed = 2;
    // , dashSpeed = 5;

    
    // [SerializeField]
    // private float currentSpeed = 0;
    // private Vector2 oldMovementInput;
    public Vector2 MovementInput { get; set; }
    // public Vector2 DashDirectionInput { get; set; }

    public bool CanSetVelocity { get; set; }
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;



    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        CanSetVelocity = true;
    }

    private void Update()
    {
        SetVelocityY(maxSpeed * MovementInput.y);
        SetVelocityX(maxSpeed * MovementInput.x);

        //below is for dash attack

        // if(MovementInput != Vector2.zero)
        // {
        //     SetVelocityY(maxSpeed * MovementInput.y);
        //     SetVelocityX(maxSpeed * MovementInput.x);
 
        // }
        // else if(MovementInput == Vector2.zero)
        // {
        //     SetVelocityY(dashSpeed * DashDirectionInput.y);
        //     SetVelocityX(dashSpeed * DashDirectionInput.x);
        // }
    }

    private void FixedUpdate()
    {
        // if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        // {
        //     oldMovementInput = MovementInput;
        //     currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        // }
        // else
        // {
        //     currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        // }
        // currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        // rb2d.velocity = oldMovementInput * currentSpeed;
        // SetVelocityY(maxSpeed * MovementInput.y);
        // SetVelocityX(maxSpeed * MovementInput.x);

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
            RB2D.velocity = workspace;
            CurrentVelocity = workspace;
        }        
    }
}
