using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
	public bool isBreakable = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Arrow"))
		{
			Destroy(other.gameObject);
			if (isBreakable)
			{
				Destroy(this.gameObject);
			}
		}
	}

}
