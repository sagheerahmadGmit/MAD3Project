using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //get the player transform
    public Transform player;

    private Vector3 target = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        //change the position of the camera on the axis
        target = new Vector3(player.position.x, player.position.y + 4, player.position.z - 8);
        //linear transition from main camera to follow camera
        transform.position = Vector3.Lerp(transform.position, target, 1f);
    }
}
