using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    //get the player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //make the player run and start the level
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
    }
}
