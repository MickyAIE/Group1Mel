using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float Health = 25f;

    public void TakeDamage(float amnt)
    {
        Health -= amnt;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
