using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    // private Agent agent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {

            StopAllCoroutines();
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                // GetPointOfContact();
                // other.GetContacts(contacts);
                // Vector3 normal = contacts[0].normal;

                Vector3 bloodDir = (GetPosition() - player.GetPosition()).normalized;
                player.playerRB.AddForce(-bloodDir, ForceMode2D.Impulse);
                player.playerRB.drag = 10f;
                // player.transform.position += bloodDir * 1f;
                BloodParticleSystemHandler.Instance.SpawnBlood(GetPosition(), bloodDir);
                player.TakeDamage(damage);
                Debug.Log(player.gameObject.name + "damaged");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.playerRB.drag = 1f;
            }
        }
    }

    // void Awake()
    // {
    //     agent = FindObjectOfType<Agent>();
    //     // agent = FindObjectsOfType<Agent>();
        
    // }
    // private void Update() 
    // {
    //     float angle = agent.Angle;
    //     if (angle < 89 && angle > -89)
    //     {
    //         transform.localScale = new Vector3(1f,1f,1f);
    //     }
    //     else
    //     {
    //         transform.localScale = new Vector3(1f,-1f,1f);
    //     }
    // }
}
