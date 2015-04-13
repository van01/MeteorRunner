using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerControl : MonoBehaviour {

	public GameObject m_skillButton = null;

	public Text m_LblSpeed;

	public Texture2D m_imgStart = null;
	public Texture2D m_imgConfirm = null;
	private PlayerContoller m_player = null;

	public Texture2D m_progressBarEmpty = null;
	public Texture2D m_progressBarFull = null;

	GUIStyle m_progressStyle = null;

	bool m_isDrawEnergyProgress = false;

	void Start()
	{
		m_player = GameManager.Instance.getPlayerController ();


		float nEvadeTime =PlayerData.instance.getEvadeLevelTime ();
		m_skillButton.GetComponent<CoolTimeButton> ().setDelayTime (nEvadeTime);
	}

	void Update()
	{
		m_LblSpeed.text = "Speed : " + PlayerData.instance.getSpeed () + 
						"\nSkill CoolTime : " + PlayerData.instance.getEvadeLevelTime ();
						  
	}

	// Use this for initialization
	void OnGUI()
	{
		switch (GameManager.Instance.getState ())
		{
		case GameManager.STATE.STATE_READY:
			/*
			if (GUI.RepeatButton ( new Rect(Screen.width/2 - 50, Screen.height-100 , 100, 50), m_imgStart))
			{
				GameManager.Instance.start();
				GameManager.Instance.changeState (GameManager.STATE.STATE_GAME);
			}
			*/
			break;

		case GameManager.STATE.STATE_GAMEOVER:
			/*
			if (GUI.RepeatButton ( new Rect(Screen.width/2 - 50, Screen.height-100 , 100, 50), m_imgConfirm))
			{
				Debug.Log ("Run on");
				Application.LoadLevel("Ready");
				GameManager.Instance.start();
			}
*/
			if (m_isDrawEnergyProgress)
			{
				float barDisplay = m_player.getEnergy()/100.0f;
				float fEnergyPercent = m_player.getEnergyPercent();
				drawProgress (fEnergyPercent, barDisplay);
			}

			break;
		case GameManager.STATE.STATE_GAME:
			onGUI_Game();
			break;
		}
	}
	
		
	void onGUI_Game()
	{
		if (m_isDrawEnergyProgress)
		{
			float barDisplay = m_player.getEnergy();
			float fEnergyPercent = m_player.getEnergyPercent ();
			drawProgress (fEnergyPercent, barDisplay);
		}
	}

	void drawProgress(float fPercent, float text)
	{
		Vector2 pos, size;

		pos.x = Screen.width / 2 - 50;
		pos.y = Screen.height - 25;
		size.x = 100.0f;
		size.y = 25.0f;

		if (m_progressStyle == null) 
		{
			m_progressStyle = new GUIStyle ();
		}

		m_progressStyle.alignment = TextAnchor.MiddleCenter;
		m_progressStyle.normal.background = m_progressBarEmpty;
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), " " + text, m_progressStyle);
		
			// draw the filled-in part:
		m_progressStyle.normal.background = m_progressBarFull;
		GUI.BeginGroup (new Rect (0, 0, size.x * fPercent, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y)," " + text, m_progressStyle);
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}
}
