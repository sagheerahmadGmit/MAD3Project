using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    //get the required gameobjects
    public GameObject player;
    public GameObject playerCanvas;
    public AudioClip theme;
    public GameObject mainMenu;

    //check if the main menu is active and if the portal gets destroyed or not
    public static bool mainMenuActive = true;
    public static bool portalDestroy = false;
    public static float score = 132;

    private void OnTriggerEnter(Collider other)
    {
        //load level 1 from leve 2
        SceneManager.LoadScene(sceneName: "Level1");

        //play running animation and start level
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
        //make sure player canvas is active
        playerCanvas.SetActive(true);

        //hide main menu and destroy the portal
        mainMenuActive = false;
        portalDestroy = true;
       
        //play the normal background music
        LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
        LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
