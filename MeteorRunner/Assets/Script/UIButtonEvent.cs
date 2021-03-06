﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButtonEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void onGameStart()
	{
		SoundEffects.instance.MakeSound_Button ();
		GameManager.Instance.changeState (GameManager.STATE.STATE_GAME);
	}

	public void onGameReload()
	{
		SoundEffects.instance.MakeSound_Button ();
		ViewManager.instance.changeState (ViewState.READY);
	}

	public void onGamePlay()
	{
		SoundEffects.instance.MakeSound_Button ();
		ViewManager.instance.changeState (ViewState.GAME);
	}

	public void onGameReady()
	{
		SoundEffects.instance.MakeSound_Button ();
		ViewManager.instance.changeState (ViewState.READY);
	}
}
