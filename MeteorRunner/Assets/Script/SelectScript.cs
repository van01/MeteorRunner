using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class SelectScript : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 260;
		const int buttonHeight = 80;
		
		// Set the skin to use
		GUI.skin = skin;
		
		// Draw a button to start the game
		if (GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(Screen.width - buttonWidth - 30, Screen.height - buttonHeight - 30, buttonWidth, buttonHeight),
			"준비 완료"
			))
		{
			// On Click, load the first level.
			Application.LoadLevel("Game"); // "Stage1" is the scene name
		}
	}
}
