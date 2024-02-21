using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeController : MonoBehaviour
{
    private TextMeshProUGUI lifeText;
	private GameObject gameOverText;

    void Update()
    {
        if (lifeText == null)
        {
        lifeText = GameObject.Find("/Canvas/Player Lives").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            lifeText.SetText("Lives: " + LoadManager.playerLives);
        }

        if (gameOverText == null)
        {
            gameOverText = GameObject.Find("/Canvas/Game Over");
            gameOverText.SetActive(false);
        }

		if (LoadManager.playerLives < 0)
        {
            StartCoroutine(GameOver());
		}
    }

    public void SetLife(int life)
    {
		LoadManager.playerLives = life;
    }

    public void AddLife(int life) 
    {
		LoadManager.playerLives += life;
    }

    public void SubtractLife(int life)
    {
		LoadManager.playerLives -= life;
    }

    IEnumerator GameOver() 
    {
        gameOverText.SetActive(true);
		lifeText.gameObject.SetActive(false);
		yield return new WaitForSeconds(4);

        LoadManager.loading = true;
        LoadManager.sceneToLoad = 0;
        SceneManager.LoadSceneAsync("LoadingScreen");
	}
}
