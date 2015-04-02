using UnityEngine;
using System.Collections;

public enum ViewState{
	NONE,
	TITLE,
	READY,
	GAME
}

public class ViewManager : Singleton<ViewManager> {

	private ViewState m_viewState = ViewState.TITLE;

	// Use this for initialization
	void Start () {
		SoundEffects.instance.setBGM(BGM.LOBBY);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeState(ViewState view)
	{
		if (m_viewState == view)
		{
			return;
		}

		switch (m_viewState)
		{
		case ViewState.TITLE:
			break;
		case ViewState.READY:
			break;
		case ViewState.GAME:
			break;
		}

		switch (view)
		{
		case ViewState.TITLE:
			Application.LoadLevel("Title");
			SoundEffects.instance.setBGM(BGM.LOBBY);
			break;
		case ViewState.READY:
			Application.LoadLevel("Ready");
			SoundEffects.instance.setBGM(BGM.LOBBY);
			break;
		case ViewState.GAME:
			Application.LoadLevel("Game");
			SoundEffects.instance.setBGM(BGM.INGAME);
			break;
		}

		m_viewState = view;
	}
}
