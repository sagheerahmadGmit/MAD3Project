using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
