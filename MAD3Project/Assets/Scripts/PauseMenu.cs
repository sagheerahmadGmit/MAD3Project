using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //get the pause menu canvas
    public GameObject pauseMenu;

    public void PauseGame()
    {
        //show the menu when paused
        pauseMenu.SetActive(true);
        //stop everything in the scene
        Time.timeScale = 0;
    }

    //resume the game
    public void ResumeGame()
    {
        //hide the menu canvas
        pauseMenu.SetActive(false);
        //start everything on the scene
        Time.timeScale = 1;
    }

    //restart the game
    public void RestartGame()
    {
        //restart the game - reload the level
        Application.LoadLevel(Application.loadedLevel);
        //everything is running
        Time.timeScale = 1;
    }

    //quit the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
