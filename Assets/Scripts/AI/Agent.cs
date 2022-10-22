using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : Character
{
    [SerializeField] public Transform muzzle;
    private AgentAnimations agentAnimations;
    private AgentMover agentMover;

    private WeaponParent weaponParent;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
    public float Angle {get; private set;}

    private void Update()
    {
        // pointerInput = GetPointerInput();
        // movementInput = movement.action.ReadValue<Vector2>().normalized;

        agentMover.MovementInput = movementInput;
        weaponParent.PointerPosition = pointerInput;
        AnimateCharacter();
    }

    public void PerformAttack()
    {
        weaponParent.Attack();
    }

    private void Awake()
    {
        agentAnimations = GetComponent<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        agentMover = GetComponent<AgentMover>();
        sp = GetComponent<SpriteRenderer>();
        defaultMat2D = GetComponent<SpriteRenderer>().material;
    }

    protected override void OnEnable()
    {
        // SetHealth();
        sp.material = defaultMat2D;
        base.OnEnable();
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        agentAnimations.RotateToPointer(lookDirection);
        // agentAnimations.CheckIfShouldFlip(Mathf.RoundToInt(pointerInput.x));
        agentAnimations.PlayAnimation(movementInput);
    }
    private void AimAndShoot()
    {
        Vector3 aim = new Vector3(movementInput.x, movementInput.y, 0f);
        if(movementInput.magnitude > 0.01f)
        {
            Angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0f,0f, Angle));
        }
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        StopCoroutine(nameof(HurtEffect));
        // ScoreManager.Instance.AddScore(scorePoint);
        // PlayerEnergy.Instance.Obtain(deathEnergyBonus);
        // EnemyManager.Instance.RemoveFromList(gameObject);
        // lootSpawner.Spawn(transform.position);
        // SpawnProjectile(numberOfColumns);
        base.Die();
    }
}
