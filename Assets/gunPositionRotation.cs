using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPositionRotation : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    public Rigidbody rigidbodyPlayer;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        rb.velocity = rigidbodyPlayer.velocity;
        transform.rotation = player.rotation;
        transform.rotation = transform.rotation * Quaternion.Euler(camera.rotation.eulerAngles.x, 0, 0);

        Vector3 newPosition = player.position;
        newPosition += transform.forward * 0.827f;
        newPosition += -transform.right * -0.296f;
        newPosition += transform.up * 0.142f;
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.225f);

        transform.rotation = transform.rotation * Quaternion.Euler(-90, 90, 0);
    }
}
