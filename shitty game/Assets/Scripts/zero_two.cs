using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zero_two : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, PlayerLayer;
    public Vector3 WalkPoint;
    bool walkPointSet;
    public float WalkPointRange;
    public float timeToAttacks;
    bool Attacked;
    public float sightRange, AttackRange;
    public bool playerInSightRange, PlayerInAttackRange;
    Rigidbody rb;
    public Animator animator;

    void Start()
    {
        animator.SetBool("IsWalking", true);
    }

    private void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerLayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, PlayerLayer);

        if (!playerInSightRange && !PlayerInAttackRange) Patrolling();
        if (playerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (PlayerInAttackRange && playerInSightRange) Attacking();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(WalkPoint);
            animator.SetBool("IsWalking", true);
        }

        Vector3 DistanceTowalkPoint = transform.position - WalkPoint;

        if (DistanceTowalkPoint.magnitude < 1)
        {
            walkPointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(WalkPoint, -transform.up, 10f, ground))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("IsWalking", true);
    }

    private void Attacking()
    {
        agent.SetDestination(transform.position);
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
        animator.SetBool("IsWalking", false);

        if (!Attacked)
        {
            Attacked = true;
            Invoke(nameof(resetAttack), timeToAttacks);
            
        }

    }

    private void resetAttack()
    {
        Attacked = false;
    }
}
