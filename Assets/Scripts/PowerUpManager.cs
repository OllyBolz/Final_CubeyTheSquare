using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PowerUp
{
    Base,
	MegaMode,
	SuperJump,
	SonicSpeed
}

public class PowerUpManager : MonoBehaviour
{
    public PowerUp powerUp;

	private TextMeshProUGUI powerUpText;

    void Awake()
    {
        powerUp = PowerUp.Base;    
    }

	void Start()
	{
		powerUpText = GameObject.Find("/Canvas/Power Up Text").GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		if (powerUp == PowerUp.Base)
		{
			PlayerController.speed = 8f;
			PlayerController.jumpPower = 40f;
			PlayerController.invincible = false;
			powerUpText.SetText("");
		}
		else if (powerUp == PowerUp.MegaMode)
		{
			PlayerController.speed = 8f;
			PlayerController.jumpPower = 40f;
			PlayerController.invincible = true;
			powerUpText.SetText("MEGA MODE");

			StartCoroutine(PowerUpDuration(10));
		}
		else if (powerUp == PowerUp.SuperJump)
		{
			PlayerController.speed = 8f;
			PlayerController.jumpPower = 50f;
			PlayerController.invincible = false;
			powerUpText.SetText("SUPER JUMP");

			StartCoroutine(PowerUpDuration(30));
		}
		else if (powerUp == PowerUp.SonicSpeed)
		{
			PlayerController.speed = 16f;
			PlayerController.jumpPower = 40f;
			PlayerController.invincible = false;
			powerUpText.SetText("SONIC SPEED");

			StartCoroutine(PowerUpDuration(30));
		}
	}

	public void ResetPowerUp()
	{
		powerUp = PowerUp.Base;
	}

	IEnumerator PowerUpDuration(int duration)
	{ 
		yield return new WaitForSeconds(duration);
		ResetPowerUp();
	}

}
