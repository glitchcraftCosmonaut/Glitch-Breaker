using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimations : MonoBehaviour
{
    private Animator animator;
    public int FacingDirection {get; private set;}

    private void Awake()
    {
        animator = GetComponent<Animator>();
        FacingDirection = 1;
    }

    public void RotateToPointer(Vector2 lookDirection)
    {
        // Vector3 scale = transform.localScale;
        Quaternion rotate = transform.localRotation;
        if (lookDirection.x > 0)
        {
            // scale.x = 1;
            rotate.y = 0f;
        }
        else if (lookDirection.x < 0)
        {
            // scale.x = -1;
            rotate.y = 180f;
        }
        // transform.localScale = scale;
        transform.localRotation = rotate;
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
        transform.Rotate(0.0f, 180f, 0.0f);
        // facingRight = !facingRight;
        // transform.Rotate(0f, 180f, 0f);
    }

    public void PlayAnimation(Vector2 movementInput)
    {
        animator.SetBool("Running", movementInput.magnitude > 0);
    }
}
