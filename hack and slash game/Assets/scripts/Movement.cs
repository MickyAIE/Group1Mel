using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 12;
    public float strafeSpeed = 6f;

    private float m_MovementInputValue;
    private float m_TurnInputValue;
    public float vertspeed;
    bool canJump = true;
    public float jumpForce = 500;
    public float dashDistance = 3;
    public float dashTime;
    public LayerMask layer;
    bool isDashing;
    float Timer;
    private bool m_PreviouslyGrounded;
    public float MoveSpeed = 12f;
    public float gravityMod = 1.2f;

    private Rigidbody _rb;

    [SerializeField]
    GameObject cameraObject;

    Vector3 nextPos;

    //rigidbody.velocity = movement * speed * speedModifier;

    // Use this for initialization
    void Start()
    {
        nextPos = gameObject.transform.forward * dashDistance;
        _rb = GetComponent<Rigidbody>();
    }

    float returnDeg(Vector3 direction)
    {
        float radian = Mathf.Atan2(direction.x, direction.z);
        float deg = radian * Mathf.Rad2Deg;
        return deg;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraDirection = cameraObject.transform.forward;
        cameraDirection.y = 0;

        Vector3 cameraRightDirection = cameraObject.transform.right;

        Vector3 finalDirection = (cameraDirection * Input.GetAxis("Vertical")) + (cameraRightDirection * Input.GetAxis("Horizontal"));
        finalDirection = finalDirection * MoveSpeed;

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            transform.rotation = Quaternion.LookRotation(finalDirection);
        }

        Debug.DrawRay(transform.position + Vector3.up, finalDirection, Color.red, 1);
        /*
        if ()
        {
            if (Input.GetButton("Jump"))
                finalDirection.y = JumpSpeed;
        }
        */

        if (Physics.Raycast(gameObject.transform.position + Vector3.up, Vector3.down, 1.1f, layer))
        {
            Debug.Log("Can Jump");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                _rb.AddForce(Vector3.up * jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        if (isDashing == true)
        {
            if (Timer < dashTime)
            {
                Vector3 DashMove = transform.forward * dashDistance;
                //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, DashMove, dashTime * Time.deltaTime);
                _rb.AddForce(DashMove);

            }
            else
            {
                Timer = 0;
                isDashing = false;
            }
            Timer += Time.deltaTime;
        }
        //cc.Move(finalDirection * MoveSpeed * Time.deltaTime);
        //_rb.velocity = finalDirection * Time.deltaTime;

        _rb.velocity = new Vector3(finalDirection.x * Time.deltaTime, _rb.velocity.y, finalDirection.z * Time.deltaTime);

        //cc.SimpleMove(Physics.gravity);
    }

    private void Dash() //Work on modifying the dash so that the character doesn't instantly warp ahead, but rather moves that distance at a faster pace.
                        //Also I'd like to make a mechanic where dashing fills a meter that once full paralyzes the character for 2-3 seconds, so the player doesn't use the dash too aggressively.
    {
        //need current position of game object, desired position of game object, float for time to get to desired position, then using rigidbody move position it needs to use vector3 lerp to move
        //the position over time, and bool to state if dash is finished.
        isDashing = true;
    }

    private void OnCollisionEnter(Collision collidingObject)
    {// The layer system may need to change as it is using layer 8, layer 8 is assigned to the post proccessing, layer 0 is the default layer and this maybe a better idea.
        if (collidingObject.gameObject.layer == 0)
        {
            canJump = true;
        }
    }
}
