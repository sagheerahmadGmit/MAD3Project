using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    //get the playercontroller
    [SerializeField] PlayerController playerController;

    //the current speed of the player
    public float currentSpeed;

    //check if the player is dashing
    public static bool dashActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the playercontroller
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses p or swipes down then dash
        if (Input.GetKeyDown(KeyCode.P) || SwipeManager.swipeDown)
        {
            dashActive = true;
            StartCoroutine(DashPlayer());
        }
    }

    //increase the speed for 1.5 seconds
    //then reset the speed back to 0
    IEnumerator DashPlayer()
    {
        dashActive = true;
        currentSpeed = PlayerController.speed;
        PlayerController.speed += 20;
        yield return new WaitForSeconds(1.5f);
        PlayerController.speed = currentSpeed;
        dashActive = false;
        Debug.Log(PlayerController.speed);
    }
}
