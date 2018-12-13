using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    // The enemys starting health
    public float startingHealth = 100f;

    // The enemys current health
    public float currentHealth;


    // The points added to the score, once the player killed an enemy
    public int scoreValue = 10;

    // Reference to the particles that hit the enemy
    //ParticleSystem hitParticles;

    // Reference to the CapsuleCollider
    BoxCollider boxCollider;

    // Check if the enemy is dead.
    bool isDead;

    private void Awake()
    {
        //hitPaticles
        boxCollider = GetComponent<BoxCollider>();

        // setting health when enemy spawns.
        currentHealth = startingHealth;
    }

    private void Update()
    {
        // make ennemy disaper if dead
    }

    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        // check if enemy died, if true exit the function
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Destroy(gameObject, 2f);
    }
}
