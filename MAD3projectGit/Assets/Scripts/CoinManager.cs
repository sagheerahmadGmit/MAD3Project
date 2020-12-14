using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public GameObject[] coins;
    public float coinTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(coinTime);
        Spawn();
    }

    private void Spawn()
    {
        float[] xPos = new float[3];
        xPos[0] = 0f;
        xPos[1] = 2.5f;
        xPos[2] = -2.5f;

        int randomXpos = UnityEngine.Random.Range(0, xPos.Length);

        Vector3 coinPosition = new Vector3(xPos[randomXpos], 1.5f, player.position.z + 20);
        Instantiate(coins[0], coinPosition, coins[0].transform.rotation);

        StartCoroutine(SpawnCoins());
    }

    // Update is called once per frame
    void Update()
    {
    }
}
