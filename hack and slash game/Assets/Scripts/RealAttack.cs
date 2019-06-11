using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealAttack : MonoBehaviour
{

    public LayerMask mask;
    public Camera cam;
    public GameObject hand;
    Animation handAnim;

    // Use this for initialization
    void Start()
    {
        //handAnim = hand.GetComponent<Animator>();
        //sword = hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            DoAttack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void DoAttack()
    {
        Debug.Log("Attack");

        RaycastHit hit;

        Vector3 p1 = transform.position;
        float distanceToObstacle = 0;

        Collider[] Enemy = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.forward * 1, 1f, mask);

        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].tag == "Enemy")
            {
                EnemyHealth hitEnemy = Enemy[i].GetComponent<EnemyHealth>();
                hitEnemy.TakeDamage(3f);
            }
        }
    }
}
