using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextLevel : MonoBehaviour
{

    public SpawnManager spawn;

    private void OnTriggerEnter(Collider other)
    {
            spawn.SpawnTriggerEntered();
    }
}
