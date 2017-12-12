using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Player's left/right movement speed
	public float speed = 10f;

    // Player's left/right movement range
    private float movementRange = 3.5f;

    // Player's max falling speed
    public float maxSpeed = 10.5f;

    // Jump variables
    public float jumpCooldown = 5f;
    public float jumpForce = 5f;
    private bool hasJumped;
    private float jumpTime = 0f;

	// The Level Manager for the current level
	public LevelManager levelManager;

	// Components of the player
    private Animator animator;
    private SpriteRenderer sprite;
	private Rigidbody2D rb2d;
	private BoxCollider2D bc2d;

	// Alternate player animation controllers
	public RuntimeAnimatorController animatorBlue;
	public RuntimeAnimatorController animatorPizza;

    // Use this for initialization
    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		bc2d = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

		if (ApplicationModel.SantaSprite == 1) {
			animator.runtimeAnimatorController = animatorBlue as RuntimeAnimatorController;
		} else if (ApplicationModel.SantaSprite == 2) {
			animator.runtimeAnimatorController = animatorPizza as RuntimeAnimatorController;
		}
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis("Horizontal");

        // Prevent jitter when player is at the edge of the playing field
        if ( (moveHorizontal > 0 && transform.position.x >= movementRange) || (moveHorizontal < 0 && transform.position.x <= -movementRange) )
            moveHorizontal = 0;

        // Set the player's left/right movement
        Vector2 velocity = rb2d.velocity;
        velocity.x = moveHorizontal * speed;
        rb2d.velocity = velocity;

        // Check if player is eligible for jumping
        hasJumped = jumpCooldownActive();

		// Update boost indicator
		levelManager.updateBoost(hasJumped);

        // Check if player is trying to jump
        if (Input.GetKeyDown("space") && !hasJumped)
        {
            rb2d.AddForce(new Vector2(0, -rb2d.velocity.y * jumpForce));
            hasJumped = true;
            jumpTime = Time.time;
        }            

        // Clamp the force on the player to prevent them from falling too fast
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);

        // Ensure player is staying in playing field
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -movementRange, movementRange), transform.position.y);

        // Update player animations based on movement
        updateAnimations(moveHorizontal);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If player has hit a collectible, disable object and increase score
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
			levelManager.updateScore();
        }

		// If player has hit an obstacle, end the game
		if (other.gameObject.CompareTag ("Obstacle")) {
			bool continueGame = levelManager.hitObstacle();
			if(continueGame)
				StartCoroutine("FlashSprite");
			else
				gameObject.SetActive(false);
		}

		// If player has the end level object, finish the level
		if (other.gameObject.CompareTag("Finish"))
		{
			gameObject.SetActive(false);
			levelManager.endLevel();
		}

		// If player has the end level bonus object, finish the level + add score bonus
		if (other.gameObject.CompareTag("FinishBonus"))
		{
			gameObject.SetActive(false);
			levelManager.endLevel(true);
		}
    }

	// When the player is hit, indicate with a flashing of the player sprite
	// Also disable box collider to prevent another immediate collision
	private IEnumerator FlashSprite()
	{
		bc2d.enabled = false;

		bool enabled = false;
		for (int i = 0; i < 6; i++) 
		{
			sprite.enabled = enabled;
			yield return new WaitForSeconds (.1f);
			enabled = !enabled;
		}

		bc2d.enabled = true;
		yield return null;
	}

    private bool jumpCooldownActive()
    {
        // Determine if enough time has passed to end cooldown
		return !((Time.timeSinceLevelLoad - jumpTime) >= jumpCooldown);
    }

    private void updateAnimations(float moveHorizontal)
    {
		// If the player is moving upwards, play the boost animation
		animator.SetBool("hasJumped", (rb2d.velocity.y > 0));

        //If the player is moving, flip the sprite so that the character is facing the right direction
        if (moveHorizontal < 0)
        	sprite.flipX = true;
        else if(moveHorizontal > 0)
        	sprite.flipX = false;
    }
}
