using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour
{
    //create an array for hearts
    public GameObject[] hearts;
    //when should the next heart spawn
    public float heartTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //get the player transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //spawn the hearts
        StartCoroutine(SpawnHearts());
    }

    IEnumerator SpawnHearts()
    {
        //wait and then spawn hearts
        yield return new WaitForSeconds(heartTime);
        Spawn();
    }

    private void Spawn()
    {
        //create an array with 3 values for the 3 different lanes on the road
        float[] xPos = new float[3];
        xPos[0] = 0f;
        xPos[1] = 2.5f;
        xPos[2] = -2.5f;

        //pick a random lane
        int randomXpos = UnityEngine.Random.Range(0, xPos.Length);

        //get the current coin position and spawn the next heart
        Vector3 coinPosition = new Vector3(xPos[randomXpos], 1.5f, player.position.z + 20);
        Instantiate(hearts[0], coinPosition, hearts[0].transform.rotation);
        //recall the co routine
        StartCoroutine(SpawnHearts());
    }
}
