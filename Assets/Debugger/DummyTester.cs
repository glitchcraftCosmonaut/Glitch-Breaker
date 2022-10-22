using UnityEngine;

public class DummyTester : Character
{
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        defaultMat2D = GetComponent<SpriteRenderer>().material;
    }

    protected override void OnEnable()
    {
        // SetHealth();
        sp.material = defaultMat2D;
        base.OnEnable();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        StopCoroutine(nameof(HurtEffect));
        base.Die();
    }
}
