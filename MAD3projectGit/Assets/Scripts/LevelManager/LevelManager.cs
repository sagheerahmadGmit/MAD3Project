using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //get the player gameobject
    public GameObject player;
    //text to display the score
    public Text score;
    //get the player score
    public static float playerScore = 0;

    //create an instance of this class
    private static LevelManager classInstance;
    //check if the game is paused - for stopping the score when game is paused
    private int framePaused = 0;
    private int frameStart = 0;
    public bool isPaused = false;

    //calculate the coins and use text to display to user
    public static int coin = 0;
    public Text coinText;

    //calculate the hearts and use text to display to user
    public static int heart = 0;
    public Text heartText;

    ////calculate the distance and use text to display on screen
    public static float distance = 0;
    public int distanceFactor = 10;
    public Text txtDistance;

    //game over canvas that will appear when player dies
    //and the player canvas will disappear
    public GameObject gameOverUI;
    public GameObject playerCanvas;

    //Game Continue
    public GameObject enemyKill;
    public int countinueCount = 0;
    public int countinueValue = 1;

    [SerializeField] PlayerController playerController;

    //main theme of music
    public AudioClip theme;

    //create an instance of this class
    public static LevelManager instance
    {
        get
        {
            if (classInstance == null)
            {
                classInstance = GameObject.FindObjectOfType<LevelManager>();
            }
            return classInstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerScore = 0;
        isPaused = false;

        //if the portal is used in level 2
        if (PortalScript.mainMenuActive == false)
        {
            //make the main menu false
            GameObject.Find("MainMenu").SetActive(false);
            //make sure player canvas is active
            playerCanvas.SetActive(true);

            //the player running animation plays
            player.GetComponent<Animator>().SetTrigger("run");
            //level start remains true
            player.GetComponent<PlayerController>().levelStart = true;

            //play the main theme of the game
            LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
            PortalScript.mainMenuActive = true;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().levelStart && !isPaused && !player.GetComponent<PlayerController>().isDead) {
            //playerscore
            playerScore += 0.1f;
            //playerScore = Mathf.RoundToInt(player.transform.position.z) / 50;

            //print out player score and distance
            score.text = ("score: " + (int)playerScore).ToString();
            distance += 0.05f;
            txtDistance.text = (int)distance + " m";

            //print out the player coins and hearts collected
            coinText.text = coin.ToString();
            heartText.text = heart.ToString();

            //increase the player speed over time
            if ((int)distance % 75 == 0)
            {
               PlayerController.speed += playerController.increaseSpeed;
            }           
        }
    }

    //continue game if the player has enough hearts
    public void GameContinue()
    {
        if (countinueCount == 0)
        {
            countinueCount = 1;
        }
        else
        {
            countinueValue = countinueValue * 2;
        }

        if (heart + 1 >= countinueValue)
        {
            //destroy enemy object
            GameObject.Destroy(enemyKill);

            //replay game music
            LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();

            //reset the player dead to false
            player.GetComponent<PlayerController>().isDead = false;
            PlayerController.speed = 10;
            player.GetComponent<Animator>().SetTrigger("run");

            // Show Player Canvas 
            playerCanvas.SetActive(true);
            // Hide Game Over Window 
            gameOverUI.GetComponent<Animator>().SetTrigger("hide");
            // Update the CollectedHearts
            heart = heart - countinueValue;
        }
    }

    public void SaveScore()
    {
        //use player prefs to save the the highest score
        //if the score is greater than the highest score
        //than set the current score to be highest score
        int HighestScore = PlayerPrefs.GetInt("HighestScore");
        if (playerScore > HighestScore)
        {
            PlayerPrefs.SetInt("HighestScore", (int)playerScore);
        }
    }

    //add the coins to the current coins
    public void SaveCoins()
    {
        //add the collected coins to the current coins 
        //to show all coins collected
        int CollectedCoins = PlayerPrefs.GetInt("CollectedCoins");
        CollectedCoins = coin + CollectedCoins;
        PlayerPrefs.SetInt("CollectedCoins", CollectedCoins);
        
    }

    //save the highest distance
    public void SaveDistance()
    {
        //use player prefs to save the the highest distance
        //if the distance is greater than the highest distance
        //than set the current distance to be highest distance
        int distanceTravelled = PlayerPrefs.GetInt("distanceTravelled");
        if ((int)distance > distanceTravelled)
        {
            PlayerPrefs.SetInt("distanceTravelled", (int)distance);
        }
    }

    //start the game
    public void StartGame()
    {     
        //play running animation and start the level
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
        //set the main menu to false and hide it and show the player canvas
        GameObject.Find("MainMenu").SetActive(false);
        playerCanvas.SetActive(true);

        //reset the player values back to 0
        playerScore = 0;
        distance = 0;
        heart = 0;
        coin = 0;
        //reset speed back to normal
        PlayerController.speed = 10;
        Debug.Log("Player score is: " + (int)playerScore);

        //play the main theme in the back ground
        LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
        LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
