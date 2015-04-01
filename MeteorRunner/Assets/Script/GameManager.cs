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

	public Sprite				m_spGameOver;
	public Sprite				m_spReady;
	public GameObject 			m_playerObject = null;
	private PlayerContoller		m_player = null;


	static string HIGHSCORE = "HighScore";

	private static GameObject container;  
	private static GameManager m_instance = null;
	private bool 				m_isGameOver;
	private float 				m_fGameSpeed 	= 1.0f;
	private float 				m_fScore 		= 0.0f;
	private float				m_fHighScore 	= 0.0f;
	private STATE				m_eState		= STATE.STATE_NONE;

	private float m_fMonsterCheckScore = 0.0f;
	private float m_fMonsterDistance = -7;


	private GameObject 			m_UIInGame;
	private GameObject			m_UIGameOver;
	private GameObject			m_UIGameReady;
	private GameObject			m_Monster;

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

	//-------------------------------------------------------------------------------------

	public void changeState (STATE eState )
	{
		switch (eState)
		{
		case STATE.STATE_NONE:
			break;
		case STATE.STATE_READY:
			onReady();
			break;
		case STATE.STATE_GAME:
			onGameStart();
			break;
		case STATE.STATE_GAMEOVER:
			onGameOver();
			break;
		}
		m_eState = eState;
	}

	//-------------------------------------------------------------------------------------

	public STATE getState()
	{
		return m_eState;
	}

	//-------------------------------------------------------------------------------------

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

	//-------------------------------------------------------------------------------------

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

	//-------------------------------------------------------------------------------------

	public void addScore (float fAddScore)
	{
		m_fScore += (fAddScore/2);
	}

	//-------------------------------------------------------------------------------------

	public float getScore()
	{
		return m_fScore;
	}

	//-------------------------------------------------------------------------------------

	public float getHighScore()
	{
		return m_fHighScore;
	}

	//-------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.Landscape;
		m_fHighScore = PlayerPrefs.GetFloat (HIGHSCORE, 0);

		m_player = m_playerObject.GetComponent<PlayerContoller>();
		m_UIInGame 		= GameObject.FindGameObjectWithTag ("UI_INGAME");
		m_UIGameOver 	= GameObject.FindGameObjectWithTag ("UI_GAMEOVER");
		m_UIGameReady	= GameObject.FindGameObjectWithTag ("UI_GAMEREADY");
		m_Monster 		= GameObject.FindGameObjectWithTag ("ENEMY_MONSTER");


		changeState (GameManager.STATE.STATE_READY);
	}

	//-------------------------------------------------------------------------------------

	// Update is called once per frame
	void Update () {
		if (m_fScore - m_fMonsterCheckScore > 30.0f)
		{
			m_fMonsterDistance += 0.5f;
			m_fMonsterCheckScore = m_fScore;
			m_Monster.GetComponent<MonsterMovement>().startAction (m_fMonsterDistance);
		}
	}

	//-------------------------------------------------------------------------------------

	public bool isIngame()
	{
		return m_eState == STATE.STATE_GAME;
	}

	//-------------------------------------------------------------------------------------

	//-------------------------------------------------------------------------------------

	void onReady() {
		m_fGameSpeed = 0.0f;

		m_UIInGame.SetActive (false);
		m_UIGameReady.SetActive (true);
		m_UIGameOver.SetActive (false);
	}

	//-------------------------------------------------------------------------------------

	void onGameStart()
	{
		m_fGameSpeed = 1.0f;

		m_UIInGame.SetActive (true);
		m_UIGameReady.SetActive (false);
		m_UIGameOver.SetActive (false);
	}

	//-------------------------------------------------------------------------------------

	void onGameOver()
	{
		m_fGameSpeed = 0.0f;
		//GameManager.Instance.isGameOver = true;
		isGameOver = true;

		m_UIInGame.SetActive (false);
		m_UIGameReady.SetActive (false);
		m_UIGameOver.SetActive (true);

		//경험치 계산
		PlayerData.instance.setExp (m_fScore);

	}

	//-------------------------------------------------------------------------------------

	public void onPlayerRun (bool isRun)
	{
		if (m_eState == STATE.STATE_GAME)
		{
			m_player.setMove (isRun);
		}
	}

	//-------------------------------------------------------------------------------------

	public GameObject getPlayerObject()
	{
		return m_playerObject;
	}

	//-------------------------------------------------------------------------------------

	public PlayerContoller getPlayerController()
	{
		return m_player;
	}

	//-------------------------------------------------------------------------------------
}
