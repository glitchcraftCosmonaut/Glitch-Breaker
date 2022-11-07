using UnityEngine;

public class DummyTester : Character
{
    public Rigidbody2D DummyRB{get; private set;}
    PlayerProjectile playerProjectile;
    private void Awake()
    {
        DummyRB = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        defaultMat2D = GetComponent<SpriteRenderer>().material;
        playerProjectile = FindObjectOfType<PlayerProjectile>();

    }

    protected override void OnEnable()
    {
        // SetHealth();
        sp.material = defaultMat2D;
        base.OnEnable();
    }
    public override void TakeDamage(float damage)
    {
        // gameObject.TryGetComponent<PlayerController>(out PlayerController player);
        // Vector3 bloodDir = (GetPosition() - player.GetPosition()).normalized;
        // BloodParticleSystemHandler.Instance.SpawnBlood(GetPosition(), bloodDir);
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        StopCoroutine(nameof(HurtEffect));
        base.Die();
    }
}
