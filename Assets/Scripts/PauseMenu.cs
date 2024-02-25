using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private int pauseMenuSelection = 0;

    private TextMeshProUGUI resumeText;
	private TextMeshProUGUI settingsText;
	private TextMeshProUGUI exitText;

	void Update()
    {

        if (resumeText == null)
        {
            resumeText = transform.Find("ResumeButton/Resume Text").gameObject.GetComponent<TextMeshProUGUI>();
        }

		if (settingsText == null)
		{
			settingsText = transform.Find("SettingsButton/Settings Text").gameObject.GetComponent<TextMeshProUGUI>();
		}

		if (exitText == null)
		{
			exitText = transform.Find("ExitButton/Exit Text").gameObject.GetComponent<TextMeshProUGUI>();
		}

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX

		if (Input.GetKeyDown(KeyCode.Escape))
        {
			Resume();
		}

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            pauseMenuSelection--;
        }
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            pauseMenuSelection++;
		}

        if (pauseMenuSelection < 0) 
        { 
        pauseMenuSelection = 2;
        }
        if (pauseMenuSelection > 2) 
        { 
        pauseMenuSelection = 0;
        }

        if (pauseMenuSelection == 0)
        {
            resumeText.color = ColorSwapper.color3;
            settingsText.color = Color.white;
            exitText.color = Color.white;

			if (Input.GetKeyDown(KeyCode.Return))
			{
				Resume();
			}
		}

		if (pauseMenuSelection == 1)
		{
			resumeText.color = Color.white;
			settingsText.color = ColorSwapper.color3;
			exitText.color = Color.white;
		}

		if (pauseMenuSelection == 2)
		{
			resumeText.color = Color.white;
			settingsText.color = Color.white;
			exitText.color = ColorSwapper.color3;

			if (Input.GetKeyDown(KeyCode.Return))
			{
				Exit();
			}
		}
#endif
	}

	public void Resume()
	{
		Time.timeScale = 1.0f;
		PlayerController.pauseMode = false;
		PlayerControllerInput.pause = false;

		this.gameObject.SetActive(false);
	}

	public void Exit()
	{
		Time.timeScale = 1.0f;
		PlayerController.pauseMode = false;
		PlayerControllerInput.pause = false;

		LoadManager.loading = true;
		LoadManager.sceneToLoad = 0;
		SceneManager.LoadSceneAsync("LoadingScreen");
	}
}
