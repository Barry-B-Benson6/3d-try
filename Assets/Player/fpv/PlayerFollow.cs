using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    Vector3 target_Offset;
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 positionAdjustment = new Vector3(0, 0.697f, 0.177f);
        target_Offset = player.position + positionAdjustment;
        verticalAiming();
    }

    void FixedUpdate()
    {
        transform.position = target_Offset;
        transform.rotation = player.rotation;
    }

    void verticalAiming()
    {
        // get the mouse inputs
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y, 0);
    }
}
