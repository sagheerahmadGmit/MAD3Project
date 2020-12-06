using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public Text score;
    public float playerScore = 0;

    private static LevelManager _instance;
    private int framePaused = 0;
    private int frameStart = 0;
    
    public bool isPaused = false;
    public int coin = 0;
    public Text coinText;

    public int heart = 0;
    public Text heartText;

    public int distance = 0;
    public int distanceFactor = 10;
    public Text txtDistance;

    public GameObject gameOverUI;
    public GameObject playerCanvas;

    //Game Continue
    public GameObject enemyKill;
    public int _countinueCount = 0;
    public int _countinueValue = 1;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().levelStart && !isPaused && !player.GetComponent<PlayerController>().isDead) {
            playerScore = Mathf.RoundToInt(player.transform.position.z) / 2;
            score.text = ("score: " + (int)playerScore).ToString();
                        
            distance = Mathf.RoundToInt(player.transform.position.z) / 10;
            txtDistance.text = distance + " m";

            coinText.text = coin.ToString();
            heartText.text = heart.ToString();

            if (distance % 75 == 0)
            {
                playerController.movementSettings.speed += playerController.increaseSpeed;
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
        if (_countinueCount == 0)
        {
            _countinueCount = 1;
        }
        else
        {
            _countinueValue = _countinueValue * 2;
        }

        if (heart + 1 >= _countinueValue)
        {
            GameObject.Destroy(enemyKill);

            LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
            LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();

            player.GetComponent<PlayerController>().isDead = false;
            player.GetComponent<PlayerController>().movementSettings.speed = 10;
            player.GetComponent<Animator>().SetTrigger("run");

            // Show Player Canvas 
            playerCanvas.SetActive(true);
            // Hide Game Over Window 
            gameOverUI.GetComponent<Animator>().SetTrigger("hide");
            // Update the CollectedHearts
            heart = heart - _countinueValue;
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
        if (distance > distanceTravelled)
        {
            PlayerPrefs.SetInt("distanceTravelled", distance);
        }
    }

    public void StartGame()
    {     
        player.GetComponent<Animator>().SetTrigger("run");
        player.GetComponent<PlayerController>().levelStart = true;
        GameObject.Find("MainMenu").SetActive(false);
        playerCanvas.SetActive(true);

        playerScore = 0;
        Debug.Log("Player score is: " + (int)playerScore);

        LevelManager.instance.gameObject.GetComponent<AudioSource>().clip = theme;
        LevelManager.instance.gameObject.GetComponent<AudioSource>().Play();
    }
}
