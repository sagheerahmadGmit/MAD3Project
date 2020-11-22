using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject followCamera;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Destroy(GameObject.Find("camChange").gameObject);
            mainCamera.SetActive(false);
        }
    }
}
