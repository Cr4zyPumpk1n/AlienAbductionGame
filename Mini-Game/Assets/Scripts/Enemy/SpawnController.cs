using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    // Reference to enemy which will be spawned 
    public Rigidbody enemy;
    public GameObject spawnerPosition;

    // Maximum enemys that can be spawned at one spawn
    public int maxEnemys = 5; 

    public float timer; 

    // Time interval of spawning
    float spawningCooldown = 10f;
    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > spawningCooldown)
        {
            // Debug.Log("Time passed:" + timer);
            Instantiate(enemy, spawnerPosition.transform.position, Quaternion.identity);
            timer = 0f;
        }

    }
    
    // Methode to despawn zombies if they are out of players reach for a certain time

}