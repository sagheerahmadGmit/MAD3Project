using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    //get coin audio
    public AudioClip pickup;

    //when the player hits the hearts
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //destroy the heart
            Destroy(this.gameObject);
            //increase the hearts
            LevelManager.heart++;
            //Play the heart pickup sound
            LevelManager.instance.gameObject.GetComponent<AudioSource>().PlayOneShot(pickup, 1);
        }
    }
}
