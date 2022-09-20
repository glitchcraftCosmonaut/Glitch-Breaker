using UnityEngine;

public class PlayerProjectile : Projectile
{
    // private SpriteRenderer spriteRender;
    private GunRotation gunRotation;

    protected virtual void Awake()
    {
        gunRotation = FindObjectOfType<GunRotation>();
        
    }
    private void Update() 
    {
        float angle = gunRotation.angle;
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
