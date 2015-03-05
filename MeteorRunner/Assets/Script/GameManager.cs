using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum STATE
	{
		STATE_NONE,
		STATE_READY,
		STATE_GAME,
		STATE_GAMEOVER,
	}

	public Sprite		m_spGameOver;
	public Sprite		m_spReady;
	
	static string HIGHSCORE = "HighScore";

	private static GameObject container;  
	private static GameManager m_instance = null;
	private bool 				m_isGameOver;
	private float 				m_fGameSpeed 	= 1.0f;
	private float 				m_fScore 		= 0.0f;
	private float				m_fHighScore 	= 0.0f;
	private STATE				m_eState		= STATE.STATE_NONE;

	public static GameManager Instance 
	{
		get 
		{
			if (m_instance == null)
			{
//				container = new GameObject();  
//				container.name = "GameManager";  
//				m_instance = container.AddComponent(typeof(GameManager)) as GameManager;  
				m_instance = GameObject.FindObjectOfType (typeof(GameManager)) as GameManager;

			}

			return m_instance;
		}
	}

	public void changeState (STATE eState )
	{
		switch (eState)
		{
		case STATE.STATE_NONE:
			break;
		case STATE.STATE_READY:
			m_fGameSpeed = 0.0f;
			onReady();
			break;
		case STATE.STATE_GAME:
			onGameStart();
			m_fGameSpeed = 1.0f;
			break;
		case STATE.STATE_GAMEOVER:
			onGameOver();
			m_fGameSpeed = 0.0f;
			break;
		}
		m_eState = eState;
	}

	public STATE getState()
	{
		return m_eState;
	}

	public bool isGameOver
	{
		get
		{
			return m_isGameOver;
		}

		set 
		{
			Debug.Log ("isGameOver : " + value);
			m_isGameOver = value;
			if (true == isGameOver)
			{
				Debug.Log ("GameOver!!");
				m_fGameSpeed = 0.0f;

				if (m_fHighScore < m_fScore)
				{
					m_fHighScore = m_fScore;
					PlayerPrefs.SetFloat (HIGHSCORE, m_fHighScore);
				}
			}
		}
	}

	public float fGameSpeed
	{
		get
		{
			return m_fGameSpeed;;
		}

		set
		{
			m_fGameSpeed = value;
		}
	}

	public void addScore (float fAddScore)
	{
		m_fScore += (fAddScore/2);
	}
	public float getScore()
	{
		return m_fScore;
	}

	public float getHighScore()
	{
		return m_fHighScore;
	}

	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.Landscape;

		m_fHighScore = PlayerPrefs.GetFloat (HIGHSCORE, 0);

		changeState (GameManager.STATE.STATE_READY);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton("Fire1"))
		{
			onClick();
		}
	}

	public bool isIngame()
	{
		return m_eState == STATE.STATE_GAME;
	}

	void onClick() {
		switch (m_eState)
		{
		case STATE.STATE_NONE:
			break;
		case STATE.STATE_READY:
			changeState (STATE.STATE_GAME);
			break;
		case STATE.STATE_GAME:
			break;
		case STATE.STATE_GAMEOVER:
			break;
		}
	}

	void onReady() {
		setLabel (m_spReady);
	}

	void onGameStart()
	{
		setLabel (null);
	}

	void onGameOver()
	{
		setLabel (m_spGameOver);
		GameManager.Instance.isGameOver = true;
	}

	void setLabel (Sprite pSprite)
	{
		GameObject label = GameObject.FindGameObjectWithTag ("LabelState");
		SpriteRenderer render = label.GetComponent<SpriteRenderer>();

		if (pSprite)
		{
			render.enabled = true;
			render.sprite = pSprite;
		}
		else
		{
			render.enabled = false;
		}

	}
}
