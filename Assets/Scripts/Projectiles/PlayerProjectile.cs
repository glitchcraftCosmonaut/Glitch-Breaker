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
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {

            StopAllCoroutines();
            if(other.gameObject.TryGetComponent<Agent>(out Agent agent))
            {
                // GetPointOfContact();
                // other.GetContacts(contacts);
                // Vector3 normal = contacts[0].normal;
                Vector3 bloodDir = (GetPosition() - agent.GetPosition()).normalized;
                agent.AgentRigidbody.AddForce(-bloodDir * 1f, ForceMode2D.Impulse);
                agent.AgentRigidbody.drag = 10f;
                // agent.transform.position -= bloodDir * 1f;
                agent.TakeDamage(damage);
                Debug.Log(agent.gameObject.name + "damaged");
                BloodParticleSystemHandler.Instance.SpawnBlood(GetPosition(), bloodDir);
            }
            // if(other.gameObject.TryGetComponent<DummyTester>(out DummyTester dummyTester))
            // {
            //     // GetPointOfContact();
            //     // other.GetContacts(contacts);
            //     // Vector3 normal = contacts[0].normal;
            //     Vector3 bloodDir = (GetPosition() - dummyTester.GetPosition()).normalized;
            //     dummyTester.DummyRB.AddForce(-bloodDir, ForceMode2D.Impulse);
            //     dummyTester.DummyRB.drag = 10f;
            //     // dummyTester.transform.position -= bloodDir * 1f;
            //     dummyTester.TakeDamage(damage);
            //     Debug.Log(dummyTester.gameObject.name + "damaged");
            //     BloodParticleSystemHandler.Instance.SpawnBlood(GetPosition(), bloodDir);
            // }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((hittable & 1 << other.gameObject.layer) != 0)
        {
            if(other.gameObject.TryGetComponent<Agent>(out Agent agent))
            {
                agent.AgentRigidbody.drag = 1f;
            }
            // if(other.gameObject.TryGetComponent<DummyTester>(out DummyTester dummyTester))
            // {
            //     dummyTester.DummyRB.drag = 1f;
            // }
        }
    }
    
    
}
