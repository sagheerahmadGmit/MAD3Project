using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //get the pause menu canvas
    public GameObject pauseMenu;
    //public GameObject mainMenu;

    //text to display score
    public Text score;

    public void PauseGame()
    {
        //show the menu when paused
        pauseMenu.SetActive(true);
        //stop everything in the scene
        Time.timeScale = 0;
        //pause game by setting game paused to true
        LevelManager.instance.isPaused = true;
    }

    //resume the game
    public void ResumeGame()
    {
        //hide the menu canvas
        pauseMenu.SetActive(false);
        //start everything on the scene
        Time.timeScale = 1;
        //game is paused
        LevelManager.instance.isPaused = false;
    }

    //restart the game
    public void RestartGame()
    {
        //restart the game - reload the level
        SceneManager.LoadSceneAsync(0);
        //everything is running
        Time.timeScale = 1;
        //LevelManager.instance.playerScore = 0;

    }

    //quit the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
