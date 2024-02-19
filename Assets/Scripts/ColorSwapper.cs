using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
	public Material scenePalette;
	public Material sceneBackgroundPalette;

	public static Color color1;
	public static Color color2;
	public static Color color3;
	public static Color color4;
	public static Color color5;
	public static Color color6;
	public static Color color7;
	public static Color color8;

    void Start()
    {
        DesignatePalette();
    }

	// Update is called once per frame
	void DesignatePalette()
	{
		if (SceneManager.GetActiveScene().name == "StartScreen" || SceneManager.GetActiveScene().name == "EndCredits") //Greyscale
		{
			ColorUtility.TryParseHtmlString("#222222", out color1); //Off Black Colour
			ColorUtility.TryParseHtmlString("#DDDDDD", out color2); //Off White Colour

			ColorUtility.TryParseHtmlString("#444444", out color3); //Dark Colour A
			ColorUtility.TryParseHtmlString("#666666", out color5); //Main Colour A
			ColorUtility.TryParseHtmlString("#888888", out color7); //White Colour A

			ColorUtility.TryParseHtmlString("#333333", out color4); //Dark Colour B
			ColorUtility.TryParseHtmlString("#555555", out color6); //Main Colour B
			ColorUtility.TryParseHtmlString("#777777", out color8); //White Colour B

		}

		if (SceneManager.GetActiveScene().name == "Level_01") //Gameboy Green
		{
			ColorUtility.TryParseHtmlString("#0F380F", out color1); //Off Black Colour
			ColorUtility.TryParseHtmlString("#BBFFBB", out color2); //Off White Colour

			ColorUtility.TryParseHtmlString("#306230", out color3); //Dark Colour A
			ColorUtility.TryParseHtmlString("#8BAC0F", out color5); //Main Colour A
			ColorUtility.TryParseHtmlString("#9BBC0F", out color7); //White Colour A

			ColorUtility.TryParseHtmlString("#043062", out color4); //Dark Colour B
			ColorUtility.TryParseHtmlString("#0430AC", out color6); //Main Colour B
			ColorUtility.TryParseHtmlString("#0430FA", out color8); //White Colour B
		}

		if (SceneManager.GetActiveScene().name == "Level_02") //Gameboy Color PKMN Yellow-esque
		{
			ColorUtility.TryParseHtmlString("#222200", out color1); //Off Black Colour
			ColorUtility.TryParseHtmlString("#FFFF88", out color2); //Off White Colour

			ColorUtility.TryParseHtmlString("#666600", out color3); //Dark Colour A
			ColorUtility.TryParseHtmlString("#888822", out color5); //Main Colour A
			ColorUtility.TryParseHtmlString("#AAAA44", out color7); //White Colour A

			ColorUtility.TryParseHtmlString("#BB4400", out color4); //Dark Colour B
			ColorUtility.TryParseHtmlString("#DD6622", out color6); //Main Colour B
			ColorUtility.TryParseHtmlString("#FF8844", out color8); //White Colour B		
		}

		if (SceneManager.GetActiveScene().name == "Level_03") //Purple 80s Synthwave Colours
		{
			ColorUtility.TryParseHtmlString("#FFDD00", out color1); //Off White Colour, normally "Off Black"
			ColorUtility.TryParseHtmlString("#330033", out color2); //Off Black Colour, normally "Off White"

			ColorUtility.TryParseHtmlString("#300400", out color3); //Dark Colour A
			ColorUtility.TryParseHtmlString("#401422", out color5); //Main Colour A
			ColorUtility.TryParseHtmlString("#502444", out color7); //White Colour A

			ColorUtility.TryParseHtmlString("#0055BB", out color4); //Dark Colour B
			ColorUtility.TryParseHtmlString("#2277DD", out color6); //Main Colour B
			ColorUtility.TryParseHtmlString("#4499FF", out color8); //White Colour B
		}

		scenePalette.SetColor("_Color1", color1);
		scenePalette.SetColor("_Color2", color2);
		scenePalette.SetColor("_Color3", color3);
		scenePalette.SetColor("_Color4", color4);
		scenePalette.SetColor("_Color5", color5);
		scenePalette.SetColor("_Color6", color6);
		scenePalette.SetColor("_Color7", color7);
		scenePalette.SetColor("_Color8", color8);

		if (sceneBackgroundPalette != null)
		{
			sceneBackgroundPalette.SetColor("_Color1", color1);
			sceneBackgroundPalette.SetColor("_Color2", color2);
			sceneBackgroundPalette.SetColor("_Color3", color3);
			sceneBackgroundPalette.SetColor("_Color4", color4);
			sceneBackgroundPalette.SetColor("_Color5", color5);
			sceneBackgroundPalette.SetColor("_Color6", color6);
			sceneBackgroundPalette.SetColor("_Color7", color7);
			sceneBackgroundPalette.SetColor("_Color8", color8);
		}
	}
}
