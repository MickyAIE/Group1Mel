using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    //needs to be put on a gamemanager(empty object)
    //the public gameobjects need to be filled in unity
    //gamemanager then needs to be placed in attack script on the player
    public Animator animation_controller;
    public GameObject _Sword;
    public GameObject _Axe;
    public GameObject _2hSword;
    public GameObject _Kniferight;
    [HideInInspector]
    public bool weaponOut = false;
    //is weapon out, default no

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//if number 1 on keyboard pressed do following
        {
            if(weaponOut == true)//if a weapon is currently in the players hand do following
            {
                animation_controller.SetTrigger("ArmReturn");//return hand to default position
                //set all weapons to false
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Sword.SetActive(false);
                //allow new weapon to be drawn
                animation_controller.SetBool("SwordActive", false);
                animation_controller.SetBool("axeActive", false);
                animation_controller.SetBool("2HActive", false);
                animation_controller.SetBool("knifeActive", false);
                // is the weapon out reset to default
                weaponOut = false;
            }
            else//if no weapon is out
            {
                //don't allow a new weapon to be drawn
                animation_controller.SetBool("SwordActive", true);
                //allow sword to be seen
                _Sword.SetActive(true);
                //is a weapon out set to true
                weaponOut = true;
            }
        }
        //the rest just copy the first just with the weapon to be drawn being different
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponOut == true)
            {
                animation_controller.SetTrigger("ArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                animation_controller.SetBool("axeActive", false);
                animation_controller.SetBool("2HActive", false);
                animation_controller.SetBool("knifeActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("axeActive", true);
                _Axe.SetActive(true);
                weaponOut = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponOut == true)
            {
                animation_controller.SetTrigger("2HArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                animation_controller.SetBool("axeActive", false);
                animation_controller.SetBool("2HActive", false);
                animation_controller.SetBool("knifeActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("2HActive", true);
                _2hSword.SetActive(true);
                weaponOut = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (weaponOut == true)
            {
                animation_controller.SetTrigger("ArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                animation_controller.SetBool("axeActive", false);
                animation_controller.SetBool("2HActive", false);
                animation_controller.SetBool("knifeActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("knifeActive", true);
                _Kniferight.SetActive(true);
                weaponOut = true;
            }
        }
    }
}