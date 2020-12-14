using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject[] portal;
    public float portalTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(portalTime);
        Spawn();
    }

    private void Spawn()
    {
        float[] xPos = new float[3];
        xPos[0] = 0f;
        xPos[1] = 2.5f;
        xPos[2] = -2.5f;

        int randomXpos = UnityEngine.Random.Range(0, xPos.Length);

        Vector3 coinPosition = new Vector3(xPos[randomXpos], 1.5f, player.position.z + 200);
        Instantiate(portal[0], coinPosition, portal[0].transform.rotation);

        StartCoroutine(SpawnCoins());
    }
}
