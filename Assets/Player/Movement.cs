using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 10000f;
    private int Crouching = 0;
    private Vector3 moveDirection;
    private Rigidbody rb;

    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private float fixedRotation = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseAiming();
        KeepRotation();
        checkMoveInput();
        //checkRotate();
        Jump();
        Crouch();
    }

    void FixedUpdate()
    {
        
    }

    void KeepRotation()
    {
        if (transform.rotation.eulerAngles.y != 0 || transform.rotation.eulerAngles.z != 0 || transform.rotation.eulerAngles.x != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, fixedRotation);
        }
    }

    void checkMoveInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.position += -transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.position += -transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.position += transform.right * Time.deltaTime * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector3(0, jumpPower, 0);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouching = 1;
            transform.localScale = new Vector3(1,0.5f,1);
        }
        else
        {
            Crouching = 0;
            transform.localScale = new Vector3(1,1,1);
        }
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

}
