using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public HUD hud;
    public AudioClip clip;
    public GameObject spawn; 
    private NavMeshAgent navMeshAgent;

    public int state;
    public GameObject player;
    public GameObject[] wayPoints;
    private int currentWay = 0;
    private int numberOfWaypoints;
    


    private void Start()
    {
        state = 1;
        //navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        numberOfWaypoints = wayPoints.Length;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (state == 1) { Patrol(); }
        if (state == 2) { Chase();  }
    }

    private void OnTriggerEnter(Collider collidedWith)
    {
        if (collidedWith.CompareTag("Player"))
        {
          
            hud.Lives = hud.Lives - 1;

           
            AudioSource.PlayClipAtPoint(clip, transform.position);

       
            collidedWith.enabled = false;

            collidedWith.transform.position = SpawnPoint.transform.position;
    
            collidedWith.enabled = true;
      
            state = 1;
          
            transform.position = EnemySpawnPoint.transform.position;
        }
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