using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //get coin audio
    public AudioClip pickup;

    //when the player hits the coin
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //destroy the coin
            Destroy(this.gameObject);
            //increase the coins
            LevelManager.coin++;
            //Play the coin pickup sound
            LevelManager.instance.gameObject.GetComponent<AudioSource>().PlayOneShot(pickup, 1);
        }
    }
}
