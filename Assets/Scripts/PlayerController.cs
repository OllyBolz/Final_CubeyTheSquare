using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private LifeController lifeController;
    private Animator playerAnim;
	private SpriteRenderer playerSprite;

	private GameObject endStar;
	public bool unpassableFinishLineOnRight = false;

	private GameObject pauseMenu;
	public static bool pauseMode = false;

    [SerializeField] private GameObject arrow;
    private bool arrowShot = false;
    private float arrowRecoil = 15f;

    public static float speed = 8f;
    public static float jumpPower = 40f;
    public static bool invincible = false;

    private bool isGrounded = false;
	private bool canJump = false;

	public bool isFacingRight = true;

    public static float deathFall = -7f;

    private float horizontalInput = 0f;

	public KeyCode jump1 = KeyCode.UpArrow;
	public KeyCode jump2 = KeyCode.W;
	public KeyCode shoot = KeyCode.Space;
	public KeyCode pause = KeyCode.Escape;



	void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        lifeController = GetComponent<LifeController>();
        playerAnim = GetComponent<Animator>();
		playerSprite = GetComponent<SpriteRenderer>();

		endStar = GameObject.Find("/Level/EndStar");

		pauseMenu = GameObject.Find("/Canvas/Pause Screen");
		pauseMenu.SetActive(false);
	}

    void Update()
    {
		if (Input.GetKeyDown(pause) && !pauseMode) //Input
		{
			Time.timeScale = 0f;
			pauseMode = true;
			pauseMenu.SetActive(true);
		}
	}

	void FixedUpdate()
    {
        //Variables
        horizontalInput = Input.GetAxis("Horizontal") * speed; //INPUT

		//Shooting Arrows
		if (Input.GetKey(shoot) && !arrowShot) //INPUT
		{
			Instantiate(arrow, transform.position, transform.rotation);
			arrowShot = true;
			if (isFacingRight)
			{
				playerRb.AddForce(new Vector2(-arrowRecoil, 0f), ForceMode2D.Impulse);
			}
			else if (!isFacingRight)
			{
				playerRb.AddForce(new Vector2(arrowRecoil, 0f), ForceMode2D.Impulse);
			}
		}
		else if (!Input.GetKey(shoot) && arrowShot) //INPUT
		{
			arrowShot = false;
		}


		//vertical(Jump)
		if ((Input.GetKey(jump1) || Input.GetKey(jump2)) && isGrounded && canJump) //INPUT
        {
            playerRb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);

            isGrounded = false;
			canJump= false;
		}

        //horizontal
        if (!arrowShot)// && isGrounded)
        {
            playerRb.velocity = new Vector2(horizontalInput, playerRb.velocity.y);

			if (unpassableFinishLineOnRight && (transform.position.x > endStar.transform.position.x) && isGrounded)
			{ 
				playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
				playerAnim.SetBool("isRunning", true);
			}
        }
		if (playerRb.velocity.x > speed)
		{ 
			playerRb.velocity = new Vector2(speed, playerRb.velocity.y); ; 
		}
		if (playerRb.velocity.x < -speed)
		{
			playerRb.velocity = new Vector2(-speed, playerRb.velocity.y); ;
		}

		//Running Animation & Direction
		if (Mathf.Abs(horizontalInput) > 0)
		{
			playerAnim.SetBool("isRunning", true);
		}
		else
		{
			playerAnim.SetBool("isRunning", false);
		}

		if (horizontalInput < 0 && !arrowShot)
		{
			isFacingRight = false;
			transform.localScale = new Vector3(-7.5f, 7.5f, 7.5f);
		}
		else if (horizontalInput > 0 && !arrowShot)
		{
			isFacingRight = true;
			transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
		}

		//Lower Bounds(Death on fall)
		if (playerRb.position.y < deathFall)
		{
			PlayerDeath();
		}

	}

    private void PlayerDeath()
    {
		lifeController.SubtractLife(1);
		if (LoadManager.playerLives >= 0)
		{
			transform.position = new Vector3(-7f, 7f, 0f);
			playerRb.velocity = new Vector2(0f, 0f);
		}
		if (LoadManager.playerLives < 0)
		{
			playerAnim.SetBool("gameOver", true);
			StartCoroutine(PlayerDisappear());
		}
	}

	private IEnumerator PlayerDisappear()
	{
		yield return new WaitForSeconds(1.3f);
		playerSprite.enabled = false;
	}


	void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.CompareTag("Jumpable"))
		{
			isGrounded = true;
		}

		if (other.gameObject.CompareTag("Enemy"))
		{
            if (!invincible)
            {
                PlayerDeath();
            }
            else if (invincible)
            {
                Destroy(other.gameObject);
            }
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Jumpable"))
		{
			canJump = true;
		}
		if (other.gameObject.CompareTag("Enemy"))
		{
			EnemySpawner enemySpawner = other.gameObject.GetComponent<EnemySpawner>();
			enemySpawner.activate = true;
		}
		if (other.gameObject.CompareTag("PowerUp"))
		{
			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("FinishLine"))
		{
			LoadManager.loading = true;
			if (LoadManager.sceneToLoad < LoadManager.numberOfLevels)
			{
				LoadManager.sceneToLoad += 1;
			}
			else
			{
				LoadManager.sceneToLoad = -1;
			}
			SceneManager.LoadSceneAsync("LoadingScreen");
		}
	}

}
