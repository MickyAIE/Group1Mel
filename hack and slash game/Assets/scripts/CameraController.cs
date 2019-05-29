using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camera controll script must be placed on a camera rig(empty object) with the camera as a child
    //camera script done by rick

    public float m_DampTime = 0.2f;
    //m_DampTime is how fast the camera follows the player
    public Transform m_target;
    //m_target is what the camera follows
    private Vector3 m_MoveVelocity;
    //just like m_DampTime m_MoveVelocity affects how fast the camera follows the player
    private Vector3 m_DesiredPosition;
    //m_DesiredPosition is where the camera starts
    private Vector3 m_DesiredRotation;
    //like desiredposition m_DesiredRotation is what rotation the camera starts at
    public GameObject camera;
    //a reference to the camera
    private bool RotateAroundPlayer = true;
    // if the camera should rotate around the player (set with m_target)
    private bool LookAtPlayer = false;
    //i honestly don't know what this does
    public float RotationSpeed = 5.0f;
    //how fast the right mouse button rotation is
    private Vector3 _Offset = new Vector3(8, 3, 5);
    //how much of an offset there is for the camera from the player when the camera starts
    private Vector3 _Home = new Vector3(0, -122, 0);
    //where the camera should return to if the player hasen't rotated recently
    public float endTimer = 30f;
    //how long the timer lasts
    private float timer = 0f;
    //actual timer(this number will go up when timer starts)
    private bool _Timer = false;
    //if the timer has started
    [SerializeField]
    private float scrollMult = 6f;
    //how fast the scrollwheel scrolls in and out

    private void Awake()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            if (RotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

                _Offset = camTurnAngle * _Offset;

                _Timer = true;
            }
        }

        if (_Timer)
        {
            timer += Time.deltaTime;
            timer = Mathf.Clamp(timer, 0f, Mathf.Infinity);
        }

        if (timer >= endTimer)
        {
            _Timer = false;
            timer = 0f;
            _Offset = Quaternion.Euler(_Home).eulerAngles;
            gameObject.transform.localRotation = Quaternion.Euler(_Home);
            return;
        }

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(m_target);
        camera.transform.Translate(camera.transform.forward * Input.GetAxis("Mouse ScrollWheel") * scrollMult, Space.World);
    }


    private void Move()
    {
        m_DesiredPosition = m_target.position + _Offset;
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
}