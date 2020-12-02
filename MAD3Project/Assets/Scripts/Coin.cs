using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickup;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            LevelManager.instance.coin++;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().PlayOneShot(pickup, 1);
        }
    }
}
