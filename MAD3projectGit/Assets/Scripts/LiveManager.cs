using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour
{
    public GameObject[] hearts;
    public float heartTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnHearts());
    }

    IEnumerator SpawnHearts()
    {
        yield return new WaitForSeconds(heartTime);
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
        Instantiate(hearts[0], coinPosition, hearts[0].transform.rotation);

        StartCoroutine(SpawnHearts());
    }
}
