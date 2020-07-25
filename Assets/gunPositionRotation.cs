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
        transform.position = player.position;
        transform.position = new Vector3(player.position.x + 1, player.position.y, player.position.z);
        transform.rotation = new Quaternion(0,90,90,0);
        //        transform.rotation = player.rotation;
        //transform.position += transform.forward * 0.827f;
        //transform.position += -transform.right * -0.296f;
        //transform.position += transform.up * 0.142f;
        //transform.rotation = new Quaternion(camera.rotation.x + 0.75f, player.rotation.y + 0.25f, camera.rotation.z, 1);
    }
}
