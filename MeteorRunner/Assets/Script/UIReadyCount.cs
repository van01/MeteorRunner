using UnityEngine;
using System.Collections;

public class UIReadyCount : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void gameStart()
	{
		GameManager.Instance.changeState (GameManager.STATE.STATE_GAME);
	}
}
