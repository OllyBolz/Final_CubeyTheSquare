using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
	private LoadManager loadManager;

	private TextMeshProUGUI pressStart;

	void Start()
	{
		loadManager = FindObjectOfType<LoadManager>();

		if (loadManager != null)
		{
			Destroy(loadManager.gameObject);
		}

		pressStart = GameObject.Find("/Canvas/Press Start").GetComponent<TextMeshProUGUI>();
		StartCoroutine(FlashPressStart());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("LoadingScreen");
		}
	}

	IEnumerator FlashPressStart()
	{ 
	while (true)
		{
			yield return new WaitForSeconds(1);
			pressStart.gameObject.SetActive(false);
			yield return new WaitForSeconds(1);
			pressStart.gameObject.SetActive(true);
		}
	}
}
