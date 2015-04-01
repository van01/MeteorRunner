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

	}

	public void goReadyScene()
	{
		// On Click, load the first level.
		Application.LoadLevel("Ready"); // "Stage1" is the scene name

		GoogleMobileAdsDemoScript.Instance.RequestBanner();
	}
}
