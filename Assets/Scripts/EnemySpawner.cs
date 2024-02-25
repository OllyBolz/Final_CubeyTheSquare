using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;

    private BoxCollider2D enemySpawnTrigger;

    public bool activate;

    void Start()
    {
        enemy = transform.Find("Enemy Body").gameObject;
		enemySpawnTrigger = GetComponent<BoxCollider2D>();

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        enemySpawnTrigger.size = new Vector2(20f, 20f);
#elif (UNITY_ANDROID || UNITY_IOS) //&& !UNITY_EDITOR
		enemySpawnTrigger.size = new Vector2(40f, 20f);
#endif


		enemy.SetActive(false);
    }

    void Update()
    {
        if (activate && enemy != null)
        {
            enemy.SetActive(true);
        }
    }
}
