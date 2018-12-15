using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
   
    // damage inflicted per bullet
    public int damagePerShot = 20;
    public float bulletSpeed;

    // The time between each shot.
    public float timeBetweenBullets = 0.15f;        
        
    // The distance the gun can fire.
    public float range = 100f;                      

    // A timer to determine when to fire.
    float timer;

    // A ray from the gun end forwards.
    Ray shootRay;
    public GameObject projectileSpawnPoint;

    // A raycast hit to get information about what was hit.
    RaycastHit shootHit;                            

    // A layer mask so the raycast only hits things on the shootable layer.
    public LayerMask shootableMask;                              
        
    // Reference to the gun particle.
    public GameObject gunParticles;                        
        
    // The proportion of the timeBetweenBullets that the effects will display for.
    float effectsDisplayTime = 0.2f;

    Quaternion rotation; 

    void Awake()
    {
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the left mouse button or ctrl-left button is being pressed, fire
        if (Input.GetButton("Fire1")&& timer >= timeBetweenBullets)
        {
            Shoot();
            //Debug.Log("Fire1 was pressed");
        }
    }
    
    void Shoot()
    {
        var bullet = Instantiate(gunParticles, projectileSpawnPoint.transform.position, rotation);
        
        // Reset the timer.
        timer = 0f;

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = projectileSpawnPoint.transform.position;
        shootRay.direction = projectileSpawnPoint.transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component is not nurll, enemy takes damage
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
        }
        // If the raycast didn't hit anything on the shootable layer, just shoot
        else
        {
            Instantiate(gunParticles);
        }
    }
}
