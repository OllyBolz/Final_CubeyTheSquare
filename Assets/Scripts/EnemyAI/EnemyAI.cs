using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
	protected Rigidbody2D enemyRb;

    public GameObject player { get; private set; }

    protected float speed;
	protected float jumpPower;
	protected float chaseRange = 1f;
	protected float leaveRange = 10f;

	protected bool isGrounded = false;
	protected bool canJump = false;

void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
		player = GameObject.Find("/Player");
	}

	void FixedUpdate()
	{
		if (enemyRb.position.y < PlayerController.deathFall)
		{
			Destroy(this.gameObject);
		}
		else
		{
			EnemyBehaviour();
		}
	}

	protected abstract void EnemyBehaviour();

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Jumpable"))
		{
			isGrounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Jumpable"))
		{
			canJump = true;
		}

		if (other.gameObject.CompareTag("Arrow"))
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
