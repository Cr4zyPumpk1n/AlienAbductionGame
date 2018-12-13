using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    // Reference to the player's movement Script
    MovementController playerMovement;


    // The players starting and current health
    public float startingHealth = 100f;
    public float currentHealth;

    // Reference to health slider
    public Slider healthSlider;
    // Reference to image to flash if player is injured
    public Image damageImage;
    public float fadeSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    // True, when the player gets damaged.
    bool damaged;                                               
    // Check if the player is dead.
    bool isDead;                   


    void Awake()
    {
        // Setting up the references.
        playerMovement = GetComponent<MovementController>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        
    }


    void Update()
    {
        // If player has been damaged, flashh image
        if (damaged)
        {
            damageImage.color = flashColor; 
        }
        // set color to clear
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(float amount)
    {
        // Set the damaged to true, so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to thhe current health
        healthSlider.value = currentHealth; 

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
