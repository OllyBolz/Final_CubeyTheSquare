using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EndCredits());
    }

    IEnumerator EndCredits()
    {
        yield return new WaitForSeconds(10);
		LoadManager.loading = true;
		LoadManager.sceneToLoad = 0;
		SceneManager.LoadSceneAsync("LoadingScreen");
	}
}
