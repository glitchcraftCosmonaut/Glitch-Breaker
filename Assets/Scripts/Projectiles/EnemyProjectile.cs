using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private Agent agent;

    protected virtual void Awake()
    {
        agent = FindObjectOfType<Agent>();
        
    }
    private void Update() 
    {
        float angle = agent.Angle;
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
