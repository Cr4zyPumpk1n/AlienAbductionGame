using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    // The players starting health
    public float startingHealth = 100f;

    // The players current health
    public float currentHealth;

    // Reference to the player's movement.
    MovementController playerMovement;
    

    // Check if the player is dead.
    bool isDead;                   
    // True, when the player gets damaged.
    bool damaged;                                               


    void Awake()
    {
        // Setting up the references.
        playerMovement = GetComponent<MovementController>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        
    }


    void Update()
    {
        
    }


    public void TakeDamage(float amount)
    {
        // Set the damaged to true, so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // If the player's health is 0 and death hasn't been set yet, it will die
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

        damaged = false; 
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off the movement script
        playerMovement.enabled = false;
    }
}
