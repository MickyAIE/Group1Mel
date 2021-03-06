﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Animator animation_controller;
    bool canAttack;
    float Timer;
    public float timeToWait = 0.5f;
    GameObject Player;
    public float attackRange = 2f;
    public PlayerHP playerhp;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange())
        {
            if (Timer > timeToWait)
            {
                DoAttack();
                Timer = 0;
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }
    }

    bool IsInRange()
    {
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) < attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DoAttack()
    {
        if (Vector3.Distance(Player.transform.position, gameObject.transform.position)<attackRange)
        {
            animation_controller.SetTrigger("Skeleton_Attack");
            playerhp.Health -= 5;
        }
    }
}
