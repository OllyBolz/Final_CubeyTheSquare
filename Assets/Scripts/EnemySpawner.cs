using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;

    public bool activate;

    void Start()
    {
        enemy = transform.Find("Enemy Body").gameObject;
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
