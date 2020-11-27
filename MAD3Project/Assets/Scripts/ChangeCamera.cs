using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    void OnTriggerEnter(Collider other)
    {
        Camera1.enabled = false;
        Camera2.enabled = true;
    }
}
