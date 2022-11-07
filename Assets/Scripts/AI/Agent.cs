using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : Character
{
    [SerializeField] public Transform muzzle;
    [SerializeField] public Transform muzzleChild;

    private AgentAnimations agentAnimations;
    private AgentMover agentMover;

    private WeaponParent weaponParent;

    private Vector2 pointerInput, movementInput, dashDirectionInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
    public Vector2 DashDirecntionInput {get => dashDirectionInput; set => dashDirectionInput = value; }
    public float Angle {get; private set;}
    public Rigidbody2D AgentRigidbody{get; private set;}
    private float nextSpawnDirtTime;
    Vector2 attackDirection;
    

    private void Awake()
    {
        attackDirection = muzzleChild.position - transform.position;
        AgentRigidbody = GetComponent<Rigidbody2D>();
        agentAnimations = GetComponent<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        agentMover = GetComponent<AgentMover>();
        sp = GetComponent<SpriteRenderer>();
        defaultMat2D = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        // pointerInput = GetPointerInput();
        // movementInput = movement.action.ReadValue<Vector2>().normalized;
        agentMover.MovementInput = movementInput;
        if (Time.time >= nextSpawnDirtTime) 
        {
            if(MovementInput.magnitude >= 0.1f)
            {
                DirtParticleSystemHandler.Instance.SpawnDirt(GetPosition() + new Vector3(0, -0.52f), GetMoveDir() * -1f);
                nextSpawnDirtTime = Time.time + .08f;
            }
        }
        agentMover.DashDirectionInput = dashDirectionInput;
        weaponParent.PointerPosition = pointerInput;
        AnimateCharacter();
    }

    public void PerformAttack()
    {
        weaponParent.Attack();
        
        // SetVelocity(dashSpeed, attackDirection);
        // dashDirectionInput = muzzleChild.position - transform.position;
        // dashDirectionInput.Normalize();
        // agentMover.transform.Translate(dashDirectionInput * dashSpeed * Time.deltaTime);
        // Vector2.MoveTowards(transform.position, muzzleChild.position, dashSpeed);
        // agentMover.rb2d.velocity = attackDirection * dashSpeed * Time.deltaTime;
        // attackDirection.Normalize();
        // agentMover.rb2d.drag = 10f;
    }

    protected override void OnEnable()
    {
        // SetHealth();
        sp.material = defaultMat2D;
        base.OnEnable();
    }

    
    public Vector3 GetMoveDir() 
    {
        return MovementInput.normalized;
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
        Vector3 aim = new Vector3(dashDirectionInput.x, dashDirectionInput.y, 0f);
        if(dashDirectionInput.magnitude > 0.01f)
        {
            Angle = Mathf.Atan2(dashDirectionInput.y, dashDirectionInput.x) * Mathf.Rad2Deg;
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
        EnemyManager.Instance.RemoveFromList(gameObject);
        // lootSpawner.Spawn(transform.position);
        // SpawnProjectile(numberOfColumns);
        base.Die();
    }
}
