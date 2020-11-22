using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public SpawnManager spawn;

    //class setup so its easier to make the variables more serialiazable
	[System.Serializable]
	public class MovementSettings{

        //how fast is the background moving
		public float speed = 10;
        //how high the player jumps
        public float jumpHeight = 18;

    }

    //class setup so its easier to make the variables more serialiazable
    [System.Serializable]
    public class PhysicsSettings
    {
        public float downAcceleration = 0.75f;

    }

    //call the class variables
    public MovementSettings movementSettings = new MovementSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();

    private Vector3 velocity;
	private Rigidbody ridgidbody;

    //check if the player is jumping or not
    private int playerJump = 0;

    //check if the player is jumping or on the ground
    private bool onGround = false;

    //variable used for moving along the x axis and the speed of moving
    private float movementX = 0;
    public float speedX = 10;

    //check if the player is dead
    public bool isDead = false;
    private Animator animator;

    // Use this for initialization
    void Start()
	{
		ridgidbody = GetComponent<Rigidbody>();
		velocity = Vector3.zero;
        animator = GetComponent<Animator>();
    }


	// Update is called once per frame
	void FixedUpdate()
	{
        //call the functions
        Run();
        InputHandling();
        CheckGround();
        Jump();
        MoveXAxis();
        ridgidbody.velocity = velocity;
    }
              
	void Run(){
		velocity.z = movementSettings.speed;
	}

    void InputHandling()
    {
        //check if the player presses space to jump
        if (Input.GetKeyDown(KeyCode.Space)) //jump
        {
            playerJump = 1;
        }
        //check if the player presses d to go right
        else if (Input.GetKeyDown(KeyCode.D)) //right
        {
            //if the position is 0 go to the right 
            if (movementX == 0)
            {
                movementX = 2.5f;
            }
            //if already on the left go to the middle
            else if (movementX == -2.5f)
            {
                movementX = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A)) //left
        {
            //if the position is 0 go to the left 
            if (movementX == 0)
            {
                movementX = -2.5f;
            }
            //if already on the right go to the middle
            else if (movementX == 2.5f)
            {
                movementX = 0;
            }
        }
    }

    void Jump()
    {
        if (playerJump == 1 && onGround)
        {
            velocity.y = movementSettings.jumpHeight;
        }
        else if (playerJump == 0 && onGround)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= physicsSettings.downAcceleration;
        }
        playerJump = 0;
    }

    void MoveXAxis()
    {
        //move the player along the x axis and keep y and z axis the same and move at the speed given
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movementX, transform.position.y, transform.position.z), Time.deltaTime * speedX);
    }

    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray, 0.5f);
        onGround = false;
        ridgidbody.useGravity = true;
        foreach (var hit in hits)
        {
            if (!hit.collider.isTrigger)
            {
                if (velocity.y <= 0)
                {
                    ridgidbody.position = Vector3.MoveTowards(ridgidbody.position,
                        new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);
                }
                ridgidbody.useGravity = false;
                onGround = true;
                break;
            }
        }
    }

    //when the player dies the player should stop moving and the dying animation plays
    public void KillPlayer()
    {
        //player is dead
        isDead = true;
        //player stops moving
        movementSettings.speed = 0;
        //Play death animation
        animator.SetTrigger("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        spawn.SpawnTriggerEntered();
    }

}
