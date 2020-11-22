﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    EndlessLevel endlessLevel;

    // Start is called before the first frame update
    void Start()
    {
        endlessLevel = GetComponent<EndlessLevel>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        endlessLevel.MoveRoad();
    }
}
