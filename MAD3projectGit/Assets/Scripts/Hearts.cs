using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{

    public AudioClip pickup;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            LevelManager.heart++;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().PlayOneShot(pickup, 1);
        }
    }
}
