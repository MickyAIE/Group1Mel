using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public Animator animation_controller;
    public GameObject _Sword;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animation_controller.SetTrigger("1hsword");
            _Sword.SetActive(true);
        }
    }
}
