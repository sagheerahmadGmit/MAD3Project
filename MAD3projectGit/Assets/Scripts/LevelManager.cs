using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public Text score;
    public static float scoreValue;
    public static float playerScore = 0;

    private static LevelManager _instance;
    private int framePaused = 0;
    private int frameStart = 0;
    
    public bool isPaused = false;
    public static int coin = 0;
    public Text coinText;

    public static int heart = 0;
    public Text heartText;

    public static float distance = 0;
    public int distanceFactor = 10;
    public Text txtDistance;

    public GameObject gameOverUI;
    public GameObject playerCanvas;

    //Game Continue
    public GameObject enemyKill;
    public int countinueCount = 0;
    public int countinueValue = 1;

    [SerializeField] PlayerController playerController;

    public AudioClip theme;

    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelManager>();
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerScore = 0;
        isPaused = false;
        if (PortalScript.mainMenuActive == false)
        {
            GameObject.Find("MainMenu").SetActive(false);
            playerCanvas.SetActive(true);

            player.GetComponent<Animator>().SetTrigger("run");
            player.GetComponent<PlayerController>().levelStart = true;

            LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
            PortalScript.mainMenuActive = true;

            //StartGame();
            //score.text = ("score: " + (int)playerScore + 132).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().levelStart && !isPaused && !player.GetComponent<PlayerController>().isDead) {
            playerScore += 0.1f; // Mathf.RoundToInt(player.transform.position.z) / 50;
            score.text = ("score: " + (int)playerScore).ToString();

            distance += 0.05f;//Mathf.RoundToInt(player.transform.position.z) / 10;
            txtDistance.text = (int)distance + " m";

            coinText.text = coin.ToString();
            heartText.text = heart.ToString();

            if ((int)distance % 75 == 0)
            {
               PlayerController.speed += playerController.increaseSpeed;
            }           
        }
        else if (!isPaused)
        {
            framePaused++;
        }
        else if (player.GetComponent<PlayerController>().levelStart == false)
        {
            frameStart++;
        }
    }

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
            GameObject.Destroy(enemyKill);

            LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();

            player.GetComponent<PlayerController>().isDead = false;
            //player.GetComponent<PlayerController>().movementSettings.speed = 10;
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
        int HighestScore = PlayerPrefs.GetInt("HighestScore");
        if (playerScore > HighestScore)
        {
            PlayerPrefs.SetInt("HighestScore", (int)playerScore);
        }
    }

    public void SaveCoins()
    {
        int CollectedCoins = PlayerPrefs.GetInt("CollectedCoins");

        CollectedCoins = coin + CollectedCoins;

        PlayerPrefs.SetInt("CollectedCoins", CollectedCoins);
        
    }

    public void SaveDistance()
    {
        int distanceTravelled = PlayerPrefs.GetInt("distanceTravelled");
        if ((int)distance > distanceTravelled)
        {
            PlayerPrefs.SetInt("distanceTravelled", (int)distance);
        }
    }

    public void StartGame()
    {     
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
        GameObject.Find("MainMenu").SetActive(false);
        playerCanvas.SetActive(true);

        playerScore = 0;
        distance = 0;
        heart = 0;
        coin = 0;
        PlayerController.speed = 10;
        //Debug.Log("Player score is: " + (int)playerScore);

        LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
        LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
