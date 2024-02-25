using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    public KeyCode jump1;
    public KeyCode jump2;
    public KeyCode shoot1;
    public KeyCode pause1;

	public static float horizontalInput = 0f;

    public static bool jump;
	public static bool shoot;
    public static bool pause;

    private GameObject interfaceUI;

    [SerializeField] private int controlScheme;

    void Start()
    {
        interfaceUI = GameObject.Find("/Canvas/Interface");

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        jump1 = KeyCode.UpArrow;
        jump2 = KeyCode.W;
        shoot1 = KeyCode.Space;
        pause1 = KeyCode.Escape;

        interfaceUI.SetActive(false);

        controlScheme = 0;
#elif (UNITY_ANDROID || UNITY_IOS) //&& !UNITY_EDITOR
        controlScheme = 1;
#endif
    }

    private void Update()
	{
        if (controlScheme == 0)
        {
            if (Input.GetKeyDown(pause1))
            {
                if (!pause)
                {
                    PauseButton();
                }
                else
                {
                    pause = false;
                }
            }
        }
        if (controlScheme == 1)
        {

        }
    }
    void FixedUpdate()
    {
        if (controlScheme == 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if ((Input.GetKey(jump1) || Input.GetKey(jump2)))
            {
                JumpButton();
            }

            if (Input.GetKeyDown(shoot1))
            {
                ShootButton();
            }
        }
        if (controlScheme == 1)
        { 
        
        }
    }

    public void JumpButton()
    {
        jump = true;
		StartCoroutine(JumpTimeOut());
	}

	public IEnumerator JumpTimeOut()
	{
		yield return new WaitForSeconds(0.05f);
		jump = false;
	}

	public void LeftButton()
    {
        horizontalInput = -1f;
    }

    public void RightButton()
    {
        horizontalInput = 1f;
    }

    public void ResetHorizontalInput()
    {
        horizontalInput = 0f;
    }

    public void ShootButton()
    {
        shoot = true;
        StartCoroutine(ShootTimeOut());
    }

    public IEnumerator ShootTimeOut()
    {
        yield return new WaitForSeconds(0.05f);
        shoot = false;
    }

    public void PauseButton()
    {
        pause = true;
    }
}
