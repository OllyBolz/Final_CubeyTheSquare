using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewBois : EnemyAI
{
	protected float speed = 3f;
	protected float jumpPower = 45f;

	protected override void EnemyBehaviour()
	{
		Vector3 travelVector = player.transform.position - transform.position;
		if (isGrounded && canJump && Mathf.Abs(travelVector.x) < leaveRange)
		{
			if (travelVector.x > chaseRange)
			{
				enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);
				transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
			}
			if (travelVector.x < -chaseRange)
			{
				enemyRb.velocity = new Vector2(-speed, enemyRb.velocity.y);
				transform.localScale = new Vector3(-7.5f, 7.5f, 7.5f);
			}

			enemyRb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
			isGrounded = false;
		}
		else if (isGrounded && Mathf.Abs(travelVector.x) > leaveRange)
		{
			enemyRb.velocity = new Vector2(0f, enemyRb.velocity.y);
		}
	}
}
