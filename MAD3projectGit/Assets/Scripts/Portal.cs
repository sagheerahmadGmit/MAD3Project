using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //change the scene to level2 and destroy the gameobject
            SceneManager.LoadScene(sceneName: "Level2");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (PortalScript.portalDestroy == true)
        {
            //if the player comes back to level 1 and portal is still there, then destroy it
            Destroy(gameObject);
        }
    }
}
