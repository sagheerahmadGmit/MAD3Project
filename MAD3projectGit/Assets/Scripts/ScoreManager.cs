using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text score;
    public static float playerScore = 0;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        playerScore = (Time.frameCount / 10f);
        //playerScore = Mathf.RoundToInt(player.transform.position.z) / 10;
        score.text = ("SCORE: " + (int)playerScore).ToString();
    }
}
