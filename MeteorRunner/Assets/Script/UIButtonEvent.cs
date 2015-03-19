using UnityEngine;
using System.Collections;

public class UIButtonEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onGameStart()
	{
		GameManager.Instance.changeState (GameManager.STATE.STATE_GAME);
	}

	public void onGameReload()
	{
		Application.LoadLevel("Ready");
	}
}
