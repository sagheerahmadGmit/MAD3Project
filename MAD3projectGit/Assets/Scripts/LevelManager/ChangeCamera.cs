using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    //get the two camera that will be changed
    public Camera Camera1;
    public Camera Camera2;

    void OnTriggerEnter(Collider other)
    {
        //when the player hits the trigger change the cameras 
        Camera1.enabled = false;
        Camera2.enabled = true;
    }
}
