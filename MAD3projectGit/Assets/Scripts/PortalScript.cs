using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCanvas;
    public AudioClip theme;
    public GameObject mainMenu;
    public static bool mainMenuActive = true;
    public static bool portalDestroy = false;
    public static float score = 132;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName: "Level1");

        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
        playerCanvas.SetActive(true);
        mainMenuActive = false;
        portalDestroy = true;
       

        LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
        LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
