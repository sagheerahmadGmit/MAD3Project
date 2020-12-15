using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    //create an array for portal
    public GameObject[] portal;
    //when should the next portal spawn
    public float portalTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //get the player transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //spawn the coins
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        //wait and then spawn coins
        yield return new WaitForSeconds(portalTime);
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

        //get the current coin position and spawn the next portal
        Vector3 coinPosition = new Vector3(xPos[randomXpos], 1.5f, player.position.z + 200);
        Instantiate(portal[0], coinPosition, portal[0].transform.rotation);
        //recall the co routine
        StartCoroutine(SpawnCoins());
    }
}
