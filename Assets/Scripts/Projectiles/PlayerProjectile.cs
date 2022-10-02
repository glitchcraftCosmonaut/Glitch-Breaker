using UnityEngine;

public class PlayerProjectile : Projectile
{
    // private SpriteRenderer spriteRender;
    private PlayerController player;

    protected virtual void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        
    }
    private void Update() 
    {
        float angle = player.Angle;
        if (angle < 89 && angle > -89)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else
        {
            transform.localScale = new Vector3(1f,-1f,1f);
        }
    }
}
