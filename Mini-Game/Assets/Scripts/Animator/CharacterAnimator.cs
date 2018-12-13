using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float smoothTime = .1f; 

    NavMeshAgent agent;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float speedPercent = agent.velocity.magnitude / agent.speed;
        //animator.SetFloat("speedPercent", speedPercent, smoothTime, Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
	}
}
