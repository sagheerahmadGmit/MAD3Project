using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinAudio;

    void OnTriggerEnter(Collider other)
    {
        coinAudio.Play();
        Destroy(this.gameObject);
    }
}
