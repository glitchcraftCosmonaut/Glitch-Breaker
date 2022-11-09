using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    // [SerializeField]
    // private Transform player;

    [SerializeField]
    public List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    public AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.5f;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    // , OnDashDirectionInput;

    [SerializeField]
    private Vector2 movementInput;
    // [SerializeField]
    // public Vector2 dashDirectionInput;

    [SerializeField]
    public ContextSolver movementDirectionSolver;
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
        // dashDirectionInput = transform.position - aiData.currentTarget.position;
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

        //dashing input
        // OnDashDirectionInput?.Invoke(dashDirectionInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            //Stopping Logic
            Debug.Log("Stopping");
            movementInput = Vector2.zero;
            // dashDirectionInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance < attackDistance)
            {
                //Attack logic
                // movementInput = Vector2.zero;
                // movementInput = direction.normalized;
                // transform.Translate(direction * 5 * Time.deltaTime);
                movementInput = Vector2.zero;
                // yield return new WaitForSeconds(.5f);
                OnAttackPressed?.Invoke();
                yield return new WaitForSeconds(attackDelay);
                // dashDirectionInput = Vector2.zero;
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                //Chase logic
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                // dashDirectionInput = Vector2.zero;
                rb.drag = 1f;
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }

        }
        // while(gameObject.activeSelf)
        // {
        //     // if(GameManager.GameState == GameState.GameOver) yield break;
        // }

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
