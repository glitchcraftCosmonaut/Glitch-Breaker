using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    // [SerializeField]
    // private Transform player;

    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    public AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.5f;
    [SerializeField]
    private float dashSpeed = 5f;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;

    [SerializeField]
    private Vector2 movementInput;

    [SerializeField]
    private ContextSolver movementDirectionSolver;
    public float distance;

    bool following = false;
    Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //Detecting Player and Obstacles around
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }

    }
     private void Update()
    {
        //Enemy AI movement based on Target availability
        if (aiData.currentTarget != null)
        {
            //Looking at the Target
            OnPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            //Target acquisition logic
            aiData.currentTarget = aiData.targets[0];
        }
        //Moving the Agent
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            //Stopping Logic
            Debug.Log("Stopping");
            movementInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance < attackDistance)
            {
                //Attack logic
                
                // movementInput = rb.velocity * dashSpeed;
                // movementInput = Vector2.MoveTowards(transform.position, player.position, dashSpeed * Time.deltaTime);
                movementInput = Vector2.zero;
                OnAttackPressed?.Invoke();
                
                // movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                // // movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                // if(aiData.currentTarget == aiData.targets[0])
                // {
                //     movementInput = aiData.currentTarget.position - transform.position;
                // }
                // movementInput = (player.position - transform.position).normalized;
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                //Chase logic
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                rb.drag = 0f;
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }

        }

    }

    // public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    // public UnityEvent OnAttack;

    // [SerializeField]
    // private Transform player;

    // [SerializeField]
    // private float chaseDistanceThreshold = 3, attackDistanceThreshold = 0.8f;

    // [SerializeField]
    // private float attackDelay = 1;
    // private float passedTime = 1;
    // [SerializeField]
    // private float dashSpeed = 5f;
    // [SerializeField]
    // private float drag = 10f;

    // Rigidbody2D enemyRigidbody;

    // private void Start()
    // {
    //     enemyRigidbody = GetComponent<Rigidbody2D>();
    // }

    // private void Update()
    // {
    //     if(player == null)
    //     {
    //         return;
    //     }

    //     float distance = Vector2.Distance(player.position, transform.position);
    //     if(distance < chaseDistanceThreshold)
    //     {
    //         OnPointerInput?.Invoke(player.position);
    //         if(distance < attackDistanceThreshold)
    //         {
                
    //             OnMovementInput?.Invoke(Vector2.zero);
    //             if(passedTime >= attackDelay)
    //             {
    //                 passedTime = 0;
    //                 OnAttack?.Invoke();
    //                 enemyRigidbody.drag = drag;
    //             }
    //         }
    //         else
    //         {
    //             Vector2 direction = player.position - transform.position;
    //             OnMovementInput?.Invoke(direction.normalized);
    //             enemyRigidbody.drag = 0;
    //         }
    //     }
    //     if(passedTime < attackDelay)
    //     {
    //         passedTime += attackDelay;
    //     }
    // }
}
