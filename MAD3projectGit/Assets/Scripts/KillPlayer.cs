using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //find the player usinf the tag
        if (other.collider.tag == "Player")
        {
            //if the player is not dead 
            if (!other.collider.GetComponent<PlayerController>().isDead)
            {
                //kill the player from the player controller
                other.collider.GetComponent<PlayerController>().KillPlayer(gameObject);
            }
        }
    }
}
