using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    // Reference to the player's position.
    public Transform player;
    // Reference to the nav mesh agent.
    public NavMeshAgent nav;

    void Awake()
    {
        // Set up the reference to the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    void Update()
    {
        nav.SetDestination(player.position);
    }
}
