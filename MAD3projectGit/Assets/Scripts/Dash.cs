using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public float currentSpeed;

    public static bool dashActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dashActive = true;
            StartCoroutine(DashPlayer());
        }
    }

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
