using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player1;
    public Transform player2;
    public LayerMask whatIsGround, whatIsPlayer1, whatIsPlayer2;

    // Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // States
    public float sightRange;
    public bool player1InSightRange, player2InSightRange;

    private void Awake()
    {
        player1 = GameObject.Find("Player1").transform;
        player2 = GameObject.Find("Player2").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if player in sight
        player1InSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer1);
        player2InSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer2);
    
        if (!player1InSightRange && !player2InSightRange)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }    

    private void ChasePlayer()
    {
        if (player1InSightRange && !player2InSightRange)
        {
            agent.SetDestination(player1.position);
        }
        else if (player1InSightRange && player2InSightRange)
        {
            bool check = Random.value > 0.5;
            if (check)
            {
                agent.SetDestination(player1.position);
            }
            else
            {
                agent.SetDestination(player2.position);
            }

        }
        else if (player2InSightRange & !player1InSightRange)
        {
            agent.SetDestination(player2.position);
        }
        
    }
}
