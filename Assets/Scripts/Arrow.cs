using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D arrowRb;

    private PlayerController playerController;
    private float direction = 0f;
    private float arrowSpeed = 3f;
    private float arrowSpeedPlus = 0f;


    void Start()
    {
        //Script Auto-Ref
        arrowRb = GetComponent<Rigidbody2D>();
		playerController = GameObject.Find("/Player").GetComponent<PlayerController>();

        //Direction of Arrow
        if (playerController.isFacingRight)
        {
            direction = 1f;
        }
        else if (!playerController.isFacingRight)
        {
            direction = -1f;
        }
		transform.localScale = new Vector3(7.5f * direction, 7.5f, 7.5f);

		//Speed of Arrow
		arrowSpeedPlus = arrowSpeed + PlayerController.speed;

	}

    void FixedUpdate()
    {
        arrowRb.velocity = new Vector2(direction, 0f) * arrowSpeedPlus;
    }

}
