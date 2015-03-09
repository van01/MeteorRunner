using UnityEngine;
using System.Collections;

public class UIPlayerControl : MonoBehaviour {
	
	public Texture2D m_imgRun 	= null;
	public Texture2D m_imgSkill = null;
	public Texture2D m_imgStart = null;
	public Texture2D m_imgConfirm = null;
	public PlayerContoller  m_player	= null;

	void OnStart()
	{
	
	}

	// Use this for initialization
	void OnGUI()
	{
		switch (GameManager.Instance.getState ())
		{
		case GameManager.STATE.STATE_READY:
			if (GUI.RepeatButton ( new Rect(Screen.width/2 - 50, Screen.height-100 , 100, 50), m_imgStart))
			{
				GameManager.Instance.start();
			}
			break;

		case GameManager.STATE.STATE_GAMEOVER:

			if (GUI.RepeatButton ( new Rect(Screen.width/2 - 50, Screen.height-100 , 100, 50), m_imgConfirm))
			{
				Debug.Log ("Run on");
				Application.LoadLevel("Game");
				GameManager.Instance.start();
			}

			break;
		case GameManager.STATE.STATE_GAME:
			if (GUI.RepeatButton ( new Rect(15, Screen.height-65 , 50, 50), m_imgRun))
			{
				Debug.Log ("Run on");
				m_player.setMove(true);
			}
			else
			{
				Debug.Log ("Run on");
				//m_player.setMove(false);
			}

			if (GUI.Button ( new Rect(Screen.width-65, Screen.height-65 , 50, 50), m_imgSkill))
			{
				m_player.skill(0);
			}
			break;
		}
	}
}
