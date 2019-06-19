using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public LayerMask mask;
    public Camera cam;
    //public GameObject hand;
    public Animator animator_controller;//animator needs to be placed on "player" i(rick) made the player into a prefab
    bool startFrames;
    float Timer;
    float timeToWait = 0.2f;
    public WeaponSelect weaponselect;
    
    void Start()
    {
        //handAnim = hand.GetComponent<Animator>();
        //sword = hand.GetComponentInChildren<Weapon>();
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(weaponselect.weaponOut == true)
            {
                DoAttack();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            startFrames = true;
        }
        //startingFrames();
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void DoAttack()
    {
        Debug.Log("Attack");

        animator_controller.SetTrigger("attack_anim");//do attack animation

        RaycastHit hit;

        Vector3 p1 = transform.position;
        //float distanceToObstacle = 0;

        Collider[] Enemy = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.forward * 1, 1f, mask);

        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].tag == "Enemy")
            {
                EnemyHP hitEnemy = Enemy[i].GetComponent<EnemyHP>();
                hitEnemy.TakeDamage(3f);
            }
        }
    }

    private void startingFrames()
    {
        if (startFrames)
        {
            if (Timer > timeToWait)
            {

                //RaycastHit hit;

                Vector3 p1 = transform.position;
                //float distanceToObstacle = 0;

                Collider[] Enemy = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.forward * 1, 1, mask);

                for (int i = 0; i < Enemy.Length; i++)
                {
                    if (Enemy[i].tag == "Enemy")
                    {
                        //EnemyHP hitEnemy = Enemy[i].GetComponent<EnemyHP>();
                        //hitEnemy.TakeDamage(5f);
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
