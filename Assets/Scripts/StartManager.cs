using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{

	private TextMeshProUGUI pressStart;

	void Start()
	{

		pressStart = GameObject.Find("/Canvas/Background/Press Start").GetComponent<TextMeshProUGUI>();

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
		pressStart.text = "Press Enter to Start";
#elif (UNITY_ANDROID || UNITY_IOS) //&& !UNITY_EDITOR
        pressStart.text = "Tap to Start";
#endif

		StartCoroutine(FlashPressStart());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			GameStart();
		}
	}

	public void GameStart()
	{
		SceneManager.LoadScene("LoadingScreen");
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
