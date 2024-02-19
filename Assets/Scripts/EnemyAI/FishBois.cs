using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBois : EnemyAI
{
	protected float speed = 10f;
	protected float glideSpeed = 4f;

	protected override void EnemyBehaviour()
	{
		Vector3 travelVector = player.transform.position - transform.position;

		if (travelVector.y > chaseRange)
		{
			enemyRb.velocity = new Vector2(enemyRb.velocity.x, glideSpeed);
		}
		if (travelVector.y < -chaseRange)
		{
			enemyRb.velocity = new Vector2(enemyRb.velocity.x, -glideSpeed);
		}

		if (travelVector.x > chaseRange && Mathf.Abs(travelVector.x) > leaveRange)
		{
			enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);
			transform.localScale = new Vector3(-7.5f, 7.5f, 7.5f);
		}
		if (travelVector.x < -chaseRange && Mathf.Abs(travelVector.x) > leaveRange)
		{
			enemyRb.velocity = new Vector2(-speed, enemyRb.velocity.y);
			transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
		}
	}
}
