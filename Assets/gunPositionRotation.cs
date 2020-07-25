using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPositionRotation : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.rotation = player.rotation;
        transform.position = player.position;
        transform.rotation = transform.rotation * Quaternion.Euler(camera.rotation.eulerAngles.x, 0, 0);
        transform.position += transform.forward * 0.827f;
        transform.position += -transform.right * -0.296f;
        transform.position += transform.up * 0.142f;
        transform.rotation = transform.rotation * Quaternion.Euler(-90, 90, 0);
    }
}
