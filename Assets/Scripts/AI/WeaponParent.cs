using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform muzzle;
    [SerializeField] public AudioData slashSFX;
    [SerializeField] public AudioData prepareAttackSFX;

    // [SerializeField] public Transform muzzleChild;
    // [SerializeField] private float dashSpeed;
    public Vector2 PointerPosition { get; set; }

    // private EnemyAI enemyAI;

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    public bool IsAttacking { get; private set; }
    // private float velocityToSet;
    // public Vector2 attackDirection;
    // private Vector2 attackDirectionInput;
    // private AgentMover agentMover;

    public Transform circleOrigin;
    public float radius;

    private void Awake()
    {
        // agentMover = GetComponentInParent<AgentMover>();
        // enemyAI = GetComponentInParent<EnemyAI>();
    }

    private void Start()
    {
        // attackDirection = enemyAI.aiData.currentTarget.position - agentMover.transform.position;
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
        
        //attack dash direction
        // attackDirection = agentMover.muzzleChild.position - agentMover.transform.position;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
    }
    public IEnumerator AttackSequence()
    {
        if (!attackBlocked && GameManager.GameState != GameState.GameOver)
        {
            PrepareAttack();
            yield return new WaitForSeconds(.5f);
            Attack();
        }
    }
    public void Attack()
    {
        // if (attackBlocked)
        //     return;
        
        animator.SetTrigger("Attack");
        AudioSetting.Instance.PlaySFX(slashSFX);
        IsAttacking = true;
        attackBlocked = true;
        // enemyAI.dashDirectionInput = enemyAI.movementDirectionSolver.GetDirectionToMove(enemyAI.steeringBehaviours, enemyAI.aiData);

        //this is for dash attack, seems like it's too op for mobs, gonna use this for boss maybe
        // enemyAI.dashDirectionInput = attackDirection;
        // agentMover.SetVelocity(velocityToSet , attackDirection);
        // agentMover.RB2D.drag = 10f;
        //     // player.playerRB.drag = player.drag;
        // }
        PoolManager.Release(projectile, muzzle.position, muzzle.transform.rotation);
        StartCoroutine(DelayAttack());
    }

    public void PrepareAttack()
    {
        animator.SetTrigger("PrepareAttack");
        AudioSetting.Instance.PlaySFX(prepareAttackSFX);
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        // animator.SetTrigger("PrepareAttack");
        // AudioSetting.Instance.PlaySFX(prepareAttackSFX);
        
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    //attack direction
    // public void SetVelocity(float velocity)
    // {
    //     agentMover.SetVelocity(velocity, attackDirection);
    //     velocityToSet = velocity;
    //     // setVelocity = true;
    // }

    // public void SetFlipCheck(bool value)
    // {
    //     shouldCheckFlip = value;
    // }

    // public void AnimationFinishTrigger()
    // {
    //     // base.AnimationFinishTrigger();
    //     isAbilityDone = true;
    // }
  
    //dash attack
    // public void AnimationStartMovementTrigger()
    // {
    //     SetVelocity(dashSpeed);
    // }

    // public void AnimationStopMovementTrigger()
    // {
    //     SetVelocity(0f);
    // }
}
