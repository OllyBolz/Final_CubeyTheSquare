using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private new Transform camera;
    private Transform player;

    private Vector3 idealCamPos;
    private float zOffset = -10f;

    void Start()
    {
        camera = GetComponent<Transform>();
        player = GameObject.Find("/Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < 0 && player.position.y < 0)
        {
            idealCamPos = new Vector3(0f, 0f, zOffset);
        }
        else if (player.position.x >= 0 && player.position.y < 0)
        {
            idealCamPos = new Vector3(player.position.x, 0f, zOffset);
        }
        else if (player.position.x < 0 && player.position.y >= 0)
        {
            idealCamPos = new Vector3(0f, player.position.y, zOffset);
        }
        else if (player.position.x >= 0 && player.position.y >= 0)
        {
            idealCamPos = new Vector3(player.position.x, player.position.y, zOffset);
        }

        if (camera.position != idealCamPos && LoadManager.playerLives >= 0)
        {
            camera.position = idealCamPos;
        }
    }
}
