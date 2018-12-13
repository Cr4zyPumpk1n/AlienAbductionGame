using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public LayerMask layer; 

    // Reference to my camera
    public Camera mainCam;
    // Reference to my target
    public Rigidbody target; 

    // distance from the player
    public Vector3 offset;

    public float clip = 4f;

    float rayLenght = 100f;
    RaycastHit hit;
    Vector3 rayDirection;

    // Rotation
    public Ray ray; 

    // Use this for initialization
    void Start ()
    {
        mainCam.transform.position = target.position;
        ray.direction = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mainCam.transform.position = target.position + offset;
        //mainCam.transform.rotation = Quaternion.FromToRotation(mainCam.transform.position, ray.direction); 
    }
}
