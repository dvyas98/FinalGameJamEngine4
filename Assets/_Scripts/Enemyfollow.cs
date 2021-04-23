using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyfollow : MonoBehaviour
{
   // public HealthBar healthBar;

    private NavMeshAgent agent;
    public Transform player;
    private Animator EnemyAnimator;
    public LayerMask whatIsGround, whatIsPlayer;


    public GameObject playerGO;
    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttack;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, PlayerInAttackRange;

    //HealthSystem healthSystem;
    
    private void Awake()
    {
        
        player = GameObject.Find("Player").transform;
        
        playerGO = GameObject.Find("Player");
        //healthSystem = GameObject.Find("Player").GetComponent<HealthSystem>();
        agent = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
       

        //healthSystem.Damage(50);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        EnemyAnimator.SetBool("isWalking", true);
        if (!playerInSightRange && !PlayerInAttackRange) Patrolling();
        if (playerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (playerInSightRange && PlayerInAttackRange) AttackPlayer();


    }

    private void Patrolling()
    {
        EnemyAnimator.SetBool("isRunning", false);


        //Debug.Log("Patrolling");
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            

            agent.SetDestination(walkPoint);
            EnemyAnimator.SetBool("isWalking", true);
        }
          

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            Debug.Log("WalkpointFalse");
        }
            

        
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }
    private void ChasePlayer()
    {
        //  Debug.Log("Chase");
        EnemyAnimator.SetBool("isRunning", true);
        //healthSystem.Damage(0.000000000001);

        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        EnemyAnimator.SetBool("isWalking", false);
        EnemyAnimator.SetBool("isRunning", false);

        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            //Decrease PlayerHealth Here.
           // Debug.Log("Damge Player");


           playerGO.GetComponent<MovementComponent>().Damage();



            //healthSystem.Damage(3);
            //Debug.Log(healthSystem.GetHealth());
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        EnemyAnimator.SetBool("isWalking", true);
        EnemyAnimator.SetBool("isRunning", false);


    }
}
