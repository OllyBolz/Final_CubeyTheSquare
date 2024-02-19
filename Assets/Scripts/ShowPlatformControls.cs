using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowPlatformControls : MonoBehaviour
{
    private TextMeshProUGUI controlsTxt;
    private bool showText = false;
    void Start()
    {
        controlsTxt = GameObject.Find("/Canvas/Controls_TXT").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleControlText();
        }
    }
    void ToggleControlText()
    {
        if (showText == false)
        {
            controlsTxt.SetText("Jump : UpArrow, W | Run: L / R, Arrow, A / D | Shoot: Space");
            showText = true;
        }
        if (showText == true)
        {
            controlsTxt.SetText("");
            showText = false;
        }
    }
}
