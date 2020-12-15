using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    private bool showMenu = true;
    public GameObject ready;

    public void ShowMenu()
    {
        //if the showMenu is true then get the animator and run the trigger show
        //set the menu to be false
        if (showMenu)
        {
            ready.SetActive(false);
            GetComponent<Animator>().SetTrigger("show");
            showMenu = false;
        }
        else
        {
            //else hide the menu and set the menu boolean back to true
            GetComponent<Animator>().SetTrigger("hide");
            ready.SetActive(true);
            showMenu = true;

        }

    }
}
