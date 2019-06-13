﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public float Health = 25f;

    public void TakeDamage(float amnt)
    {
        Health -= amnt;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
