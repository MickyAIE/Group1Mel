﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float m_DampTime = 0.2f;


    public Transform m_target;

    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    [SerializeField]
    private float scrollMult = 6f;

    private void Awake()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize += scroll * scrollMult;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 8, 15);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


}
