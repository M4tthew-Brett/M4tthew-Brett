using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int state;
    public GameObject player;
    public GameObject[] wayPoints;
    private int currentWay = 0;
    private int numberOfWaypoints;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Start()
    {
        state = 1;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        numberOfWaypoints = wayPoints.Length;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (state == 1) { Patrol(); }
        if (state == 2) { chase();  }
    }

    private void Patrol()
    {
        navMeshAgent.destination = wayPoints[currentWaypoint].transform.position;
        if (navMeshAgent.pathPending == false && navMeshAgent.remainingDistance < 0.001f)
        {
            if (currentWaypoint + 1 == numberOfWaypoints)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }
    }

    private void Chase()
    {
        navMeshAgent.destination = player.transform.position;

    }
}