using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed;

    public float despawnTime = 20f;

    public float timer; 

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        if (timer > despawnTime)
        {
            Destroy(this.gameObject);
        }
    }
}
