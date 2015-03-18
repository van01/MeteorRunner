using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 128;
		const int buttonHeight = 60;
		
		// Set the skin to use
		GUI.skin = skin;
		
		// Draw a button to start the game
		if (GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(Screen.width / 2 - (buttonWidth / 2), (Screen.height - Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight),
			"게임 시작"
			))
		{
			// On Click, load the first level.
			Application.LoadLevel("Ready"); // "Stage1" is the scene name
		}
	}
}
