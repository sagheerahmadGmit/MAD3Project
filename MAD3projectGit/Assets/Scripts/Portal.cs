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
            SceneManager.LoadScene(sceneName: "Level2");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (PortalScript.portalDestroy == true)
        {
            Destroy(gameObject);
        }
    }
}
