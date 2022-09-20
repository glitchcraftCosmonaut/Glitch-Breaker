using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [HideInInspector] public float angle;
    public float offset;
    private SpriteRenderer spriteRender;
    private PlayerProjectile playerProjectile;
    public PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        playerProjectile = FindObjectOfType<PlayerProjectile>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = playerInput.MousePos - transform.position;
        angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f, angle + offset));
        if (angle < 89 && angle > -89)
        {
            // Debug.Log("Facing right");
            spriteRender.flipY = false;

        }
        else
        {
            // Debug.Log("Facing left");
            spriteRender.flipY = true;
        }
    }
}

