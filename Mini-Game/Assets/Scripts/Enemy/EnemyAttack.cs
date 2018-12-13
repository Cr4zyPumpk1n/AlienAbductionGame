using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    // Time between attacks
    public float timeBetweenAttacks = 0.5f;
    // The ammount of damage done by the enemy.
    public float attackDamage = 10f;

    public GameObject enemy;

    // Reference to the player
    GameObject player;

    // References to player's and enemy's health
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    // Check if the player is in hit range
    bool inHitRange;

    //Timer to count until the next attack.
    float timer;

    private void Start()
    {
        // Setting up references
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            inHitRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            inHitRange = false;
        }
    }

    private void Update()
    {
        // Add the time since last update was called to the timer.
        timer += Time.deltaTime;
        
        // If timer is bigger than the time beween attacks and the player is in Range and the enemy is still alive, it attacks
        if (timer >= timeBetweenAttacks && inHitRange  && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        // If the player has 0 or less health, the player is dead.
        if (playerHealth.currentHealth <= 0 )
        {
            // end of game
        }
    }
    
    void Attack()
    {
        // reset the timer
        timer = 0f;

        // Damage the player, if his health is larger than 0 
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

}
