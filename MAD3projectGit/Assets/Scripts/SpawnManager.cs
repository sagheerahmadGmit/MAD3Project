using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //call the endless level class
    EndlessLevel endlessLevel;

    // Start is called before the first frame update
    void Start()
    {
        //get the component
        endlessLevel = GetComponent<EndlessLevel>();   
    }

    //spawn the next part of the level
    public void SpawnTriggerEntered()
    {
        endlessLevel.MoveRoad();
    }
}
