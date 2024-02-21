using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
	private int defaultLives = 9;
	public static int playerLives;
	public static LoadManager loadManager;
	public static int numberOfLevels = 3;
    public static int sceneToLoad = 1;
    public static bool loading = true;

    private string loadScene;

    void Start()
    {
		if (loadManager != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			loadManager = this;
			DontDestroyOnLoad(this.gameObject);
			///Non Singleton Code
			playerLives = defaultLives;
			sceneToLoad = 1;
			loading = true;
		}
	}

    void Update()
    {
		if (loading && SceneManager.GetActiveScene().name == "LoadingScreen")
		{
			if (sceneToLoad == -1)
			{
				loadScene = "EndCredits";
			}
			if (sceneToLoad == 0)
			{
				loadScene = "StartScreen";
			}
			if (sceneToLoad == 1)
			{
				loadScene = "Level_01";
			}
			if (sceneToLoad == 2)
			{
				loadScene = "Level_02";
			}
			if (sceneToLoad == 3)
			{
				loadScene = "Level_03";
			}

			StartCoroutine(LoadScene());
			loading = false;	
		}

		if (SceneManager.GetActiveScene().name == "StartScreen")
		{
			Destroy(this.gameObject);
		}
	}

    IEnumerator LoadScene() 
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(loadScene);
    }
}
