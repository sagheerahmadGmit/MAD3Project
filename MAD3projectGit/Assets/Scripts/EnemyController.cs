using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //player transform
    private Transform player;
    //speed of car
    public int carSpeed = 10;
    //only move car if a distance away
    public int carDistance = 100;

    void Start()
    {
        //find the player
        player = GameObject.Find("Player").transform;
        //get a random number between 1 and 3 to decide lane for car
        int randomNum = Random.Range(1, 3);

        //if 1 then have the car in the left lane
        if (randomNum == 1)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        //have the car in the middle
        else if (randomNum == 2)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        //have the car on the left
        else
        {
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }
    }


    void FixedUpdate()
    {
        //check if the player is dead
        if (!GameObject.Find("Player").GetComponent<PlayerController>().isDead)
        {
            //if the distance of the car from the player is less then 100 then move the car
            if (Vector3.Distance(transform.position, player.position) <= carDistance)
            {
                //move on the z axis because the car can only go straight
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - carSpeed * Time.deltaTime);
            }
        }
    }

    //when the player hits the car then the car should stop moving
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            carSpeed = 0;
        }
    }
}
