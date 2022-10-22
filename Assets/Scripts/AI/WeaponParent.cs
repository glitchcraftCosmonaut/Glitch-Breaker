using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform muzzle;
    [SerializeField] public Transform muzzleChild;
    [SerializeField] float dashSpeed = 5f;
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }

    private EnemyAI enemyAI;

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    public bool IsAttacking { get; private set; }
    private float velocityToSet;
    public Vector2 attackDirection;
    private Vector2 attackDirectionInput;
    private AgentMover agentMover;

    public Transform circleOrigin;
    public float radius;

    private void Awake()
    {
        agentMover = GetComponentInParent<AgentMover>();
        enemyAI = GetComponentInParent<EnemyAI>();
    }

    private void Start()
    {
        // attackDirection = enemyAI.aiData.currentTarget.position - agentMover.transform.position;
        attackDirection = (PointerPosition - (Vector2)transform.position).normalized;
    }
    public void ResetIsAttacking()
    {
        // animator.SetBool("Attack", false);
        IsAttacking = false;
    }

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        IsAttacking = true;
        attackBlocked = true;
        // Vector2 direction = enemyAI.aiData.currentTarget.position - agentMover.transform.position;
        // direction.Normalize();
        // agentMover.rb2d.AddForce(attackDirection * dashSpeed, ForceMode2D.Force);
        agentMover.transform.Translate(-(attackDirection * dashSpeed) * Time.deltaTime);
        // agentMover.rb2d.velocity = attackDirection * dashSpeed * Time.deltaTime;
        // attackDirection.Normalize();
        agentMover.rb2d.drag = 10f;
        // attackDirectionInput = agentMover.MovementInput;
        // if(attackDirectionInput != Vector2.zero)
        // {
        //     attackDirection = attackDirectionInput;
        //     attackDirection.Normalize();
        //     agentMover.SetVelocity(velocityToSet, attackDirection);
        //     agentMover.rb2d.drag = 10f;
        //     // player.playerRB.drag = player.drag;
        // }
        // else
        // {
        //     agentMover.SetVelocity(velocityToSet, attackDirection);
        //     agentMover.rb2d.drag = 10f;
        //     // player.playerRB.drag = player.drag;
        // }
        // Vector2 direction = muzzle.position - agentMover.transform.position;
        // agentMover.SetVelocity(velocityToSet, attackDirection);
        // agentMover.rb2d.AddForce(attackDirection * dashSpeed, ForceMode2D.Impulse);
        // agentMover.rb2d.velocity = PointerPosition * dashSpeed;
        PoolManager.Release(projectile, muzzle.position, muzzle.transform.rotation);
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void SetVelocity(float velocity)
    {
        agentMover.SetVelocity(velocity, attackDirection);
        velocityToSet = velocity;
        // setVelocity = true;
    }

    // public void SetFlipCheck(bool value)
    // {
    //     shouldCheckFlip = value;
    // }

    // public void AnimationFinishTrigger()
    // {
    //     // base.AnimationFinishTrigger();
    //     isAbilityDone = true;
    // }
  

    public void AnimationStartMovementTrigger()
    {
        SetVelocity(dashSpeed);
    }

    public void AnimationStopMovementTrigger()
    {
        SetVelocity(0f);
    }
}
