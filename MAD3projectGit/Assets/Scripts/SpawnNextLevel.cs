using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextLevel : MonoBehaviour
{
    //spawn the next part of the level
    public SpawnManager spawn;

    private void OnTriggerEnter(Collider other)
    {
            spawn.SpawnTriggerEntered();
    }
}
