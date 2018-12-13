using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyController: MonoBehaviour
{
    // Reference to the nav mesh agent.
    public NavMeshAgent nav;

    // Reference to the player's position.
    Transform player;

    bool damaged = false;

    // Enemy stats
    public float enemyHealth = 100f;
    public float enemyAttackDamage;
    public float enemyAttackRange;

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
