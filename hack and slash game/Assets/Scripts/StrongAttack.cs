﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : MonoBehaviour
{

    public LayerMask mask;
    public Camera cam;
    public GameObject hand;
    Animation handAnim;
    bool startFrames;
    float Timer;
    float timeToWait = 0.2f;

    // Use this for initialization
    void Start()
    {
        //handAnim = hand.GetComponent<Animator>();
        //sword = hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            startFrames = true;
        }
        startingFrames();
    }

    private void startingFrames()
    {
        if (startFrames)
        {
            if (Timer > timeToWait)
            {

                RaycastHit hit;

                Vector3 p1 = transform.position;
                float distanceToObstacle = 0;

                Collider[] Enemy = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.forward * 1, 1, mask);

                for (int i = 0; i < Enemy.Length; i++)
                {
                    if (Enemy[i].tag == "Enemy")
                    {
                        EnemyHealth hitEnemy = Enemy[i].GetComponent<EnemyHealth>();
                        hitEnemy.TakeDamage(5f);
                    }
                }

                startFrames = false;
                Timer = 0;
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }
    }
}