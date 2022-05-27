using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player1;
    public Transform player2;
    public Transform walkDest;
    public LayerMask whatIsGround, whatIsPlayer1, whatIsPlayer2;

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
    
        if (player1InSightRange || player2InSightRange)
        {
            ChasePlayer();
        }
        else
        {
            DoNothing();
        }
    } 

    private void DoNothing()
    {
        agent.SetDestination(walkDest.position);
    }

    private void ChasePlayer()
    {
        if (player1InSightRange && !player2InSightRange)
        {
            agent.SetDestination(player1.position);
        }
        else if (player1InSightRange && player2InSightRange)
        {
            agent.SetDestination(player1.position);
        }
        else if (player2InSightRange && !player1InSightRange)
        {
            agent.SetDestination(player2.position);
        }
        
    }
}


