using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Player's movement speed
	public float speed = 10f;

    // Player's max movement speed
    public float maxSpeed = 10.5f;

	// public Animator animator;
	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	// private SpriteRenderer sprite;  //Store a reference to the sprite renderer

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D + SpriteRenderer component so that we can access it.
		rb2d = GetComponent<Rigidbody2D>();
		// sprite = GetComponent<SpriteRenderer>();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //If the player is moving, flip the sprite so that the character is facing the right direction
        //		if(moveHorizontal < 0)
        //		{
        //			animator.SetBool("isWalking", true);
        //			sprite.flipX = true;
        //		}
        //		else if(moveHorizontal > 0)
        //		{
        //			animator.SetBool("isWalking", true);
        //			sprite.flipX = false;
        //		}
        //		else
        //		{
        //			animator.SetBool("isWalking", false);
        //		}

        // Set the player's left/right movement
        Vector2 velocity = rb2d.velocity;
        velocity.x = moveHorizontal * speed;
        rb2d.velocity = velocity;

        // Set the player's up/down movement
        // Clamp the player's movement so that they can't stop or go in the opposite direction
        Vector2 movement = new Vector2(0, Mathf.Clamp(moveVertical, -.5f, .5f));
        //Vector2 movement = new Vector2(0, moveVertical);
        rb2d.AddForce(movement * speed);

        // Clamp the force on the player to prevent them from falling too fast
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
    }
}
