using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //get the player transform
    public PlayerController player;
    //pause menu to hide menu 
    public GameObject pauseMenu;

    //animators to hide pause menu and show scoreboard
    public Animator achievementAnimator;
    public Animator gameOverAnimator;

    //get the data for the current score details and the all time
    public Text currentCoins, allCoins, currentScore, highestScore, currentDistance, highestDistance;
    //create an instance of the menu class
    private static Menu instance;

    //create an instance of the menu class
    public static Menu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Menu>();
            }
            return instance;
        }
    }

    //pause the game - show the pause menu
    //pause everything in the game using timescale
    public void PauseGame()
    {
        if (!player.isDead)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            LevelManager.instance.isPaused = true;
        }
    }

    //reusme the game - show pause menu
    //timescale goes back to normal
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        LevelManager.instance.isPaused = false;
    }

    //restart the level by loading scene 0
    public void RestartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);

    }

    //exit the application
    public void Exit()
    {
        Application.Quit();
    }

    //show the results which we save in the level manager class
    public void ShowAchievements()
    {
        gameOverAnimator.SetTrigger("hide");
        // Get Data 
        currentCoins.text = LevelManager.instance.coin.ToString();
        currentDistance.text = LevelManager.instance.distance.ToString();
        currentScore.text = ((int)LevelManager.instance.playerScore).ToString();

        // all time data
        allCoins.text = PlayerPrefs.GetInt("CollectedCoins").ToString();
        highestDistance.text = PlayerPrefs.GetInt("distanceTravelled").ToString();
        highestScore.text = PlayerPrefs.GetInt("HighestScore").ToString();

        achievementAnimator.SetTrigger("show");
    }

    public void ControlAudio()
    {

        // Adjusting the volume 
        if (LevelManager.instance.gameObject.GetComponent<AudioSource>().volume == 0)
        {
            LevelManager.instance.gameObject.GetComponent<AudioSource>().volume = 1;//volume full
        }
        else
        {
            LevelManager.instance.gameObject.GetComponent<AudioSource>().volume = 0; // Mute
        }
    }
}
