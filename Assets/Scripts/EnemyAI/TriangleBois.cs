using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBois : EnemyAI
{
	protected float speed = 4f;
	protected float jumpPower = 15f;

	protected override void EnemyBehaviour()
	{
		Vector3 travelVector = player.transform.position - transform.position;
		if (isGrounded && canJump && Mathf.Abs(travelVector.x) < leaveRange)
		{
			if (Mathf.Abs(travelVector.x) <= chaseRange && travelVector.y > 0)
			{
				enemyRb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
				isGrounded = false;
			}
			else if (travelVector.x > chaseRange)
			{
				enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);
				transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
			}
			else if (travelVector.x < -chaseRange)
			{
				enemyRb.velocity = new Vector2(-speed, enemyRb.velocity.y);
				transform.localScale = new Vector3(-7.5f, 7.5f, 7.5f);
			}
		}
		else if (isGrounded && Mathf.Abs(travelVector.x) > leaveRange)
		{
			enemyRb.velocity = new Vector2(0f, enemyRb.velocity.y);
		}
	}
}
