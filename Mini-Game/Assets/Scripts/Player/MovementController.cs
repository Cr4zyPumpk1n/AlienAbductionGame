using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    // Reference to the player
    public Rigidbody player;
    

    // movement speed
    public float moveSpeed = 1f;

    // Camera to cast a ray from
    public Camera mainCam;

    public LayerMask layer; 

    Vector3 movement;   // variable to store the movement 
    Ray ray;            // variable to store the ray

    // where the raycast hits
    public RaycastHit hit;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        RotatePlayer();
        Interact();
    }

    void RotatePlayer()
    {
        // cast a ray from the camera
        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
        
        // rotate the player to that position
        if (Physics.Raycast(camRay, out hit, layer))
        {
            Vector3 lookRotatoin = hit.point - transform.position;
            lookRotatoin.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(lookRotatoin);

            player.MoveRotation(rotation);

            //Debug.Log("You hit at: " + hit.point);
        }

    }

    void Move()
    {
        moveSpeed = 0.1f; 

        // move forward
        if (Input.GetKey(KeyCode.W))
        {
            player.position += Vector3.forward * moveSpeed;
            
        }

        // move backward
        if (Input.GetKey(KeyCode.S))
        {
            player.position += Vector3.back * moveSpeed;
        }

        // move left
        if (Input.GetKey(KeyCode.A))
        {
            player.position += Vector3.left * moveSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D))
        {
            player.position += Vector3.right * moveSpeed;
        }

    }

    void Interact()
    {
        // If right mous button is pressed, cast ray, detect interacables and interact
        if (Input.GetMouseButton(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interacable interacable = hit.collider.GetComponent<Interacable>();
                if (interacable != null)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }


}
