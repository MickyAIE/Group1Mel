using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowPlayer : MonoBehaviour {

    public Transform follow;
    public Animator animation_controller;

    NavMeshAgent agent;
    float timer = 0;
    bool isDetected;

    public float DetectionRange = 5f;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        animation_controller.SetFloat("enemy_walking_float", agent.velocity.magnitude);//do animation

        if (IsInRange() && timer <= 0)
        {
            if (Vector3.Distance(follow.position,gameObject.transform.position) < 1f)
            {
                agent.isStopped = true;
            }
            else//follow
            {
                agent.isStopped = false;

                agent.SetDestination(follow.position);
            }
            timer = 1;
        }
        if (Vector3.Distance(follow.position, gameObject.transform.position) < 1f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
        timer -= Time.deltaTime;
	}

    bool IsInRange()
    {
        if (Vector3.Distance(gameObject.transform.position, follow.position) < DetectionRange )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
