using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public Animator animation_controller;
    public GameObject _Sword;
    public GameObject _Axe;
    public GameObject _2hSword;
    public GameObject _Kniferight;
    public GameObject _Knifeleft;

    private bool weaponOut = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponOut == true)
            {
                animation_controller.SetTrigger("ArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Knifeleft.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("SwordActive", true);
                _Sword.SetActive(true);
                weaponOut = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponOut == true)
            {
                animation_controller.SetTrigger("ArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Knifeleft.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("SwordActive", true);
                _Axe.SetActive(true);
                weaponOut = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponOut == true)
            {
                animation_controller.SetTrigger("ArmReturn");
                _Axe.SetActive(false);
                _2hSword.SetActive(false);
                _Kniferight.SetActive(false);
                _Knifeleft.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("SwordActive", true);
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
                _Knifeleft.SetActive(false);
                _Sword.SetActive(false);
                animation_controller.SetBool("SwordActive", false);
                weaponOut = false;
            }
            else
            {
                animation_controller.SetBool("SwordActive", true);
                _Kniferight.SetActive(true);
                _Knifeleft.SetActive(true);
                weaponOut = true;
            }
        }
    }
}