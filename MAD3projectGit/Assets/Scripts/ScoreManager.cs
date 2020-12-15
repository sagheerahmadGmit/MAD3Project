using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //text to print out score
    public Text score;
    //player score
    public static float playerScore = 0;
    //get the player object
    public GameObject player;
    
    void Update()
    {
        //calculate the playerscore using player z position
        //playerScore = Mathf.RoundToInt(player.transform.position.z) / 10;
        //print score to screen
        score.text = ("SCORE: " + (int)playerScore).ToString();
    }
}
