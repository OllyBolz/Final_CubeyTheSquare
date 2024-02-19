using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    private PowerUpManager powerUpManager;
	public PowerUp powerUp;

	void Start()
    {
        powerUpManager = GameObject.Find("/Player").GetComponent<PowerUpManager>();
    }

    void OnDestroy()
    {
        powerUpManager.powerUp = powerUp;
    }
}
