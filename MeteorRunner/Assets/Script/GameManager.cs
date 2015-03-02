using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum eState{eSTATE_INIT, eSTATE_READY, eSTATE_INGAME, eSTATE_GAMEOVER};
	private eState	m_state;
	private static GameObject container;  
	private static GameManager m_instance = null;
	private bool m_isGameOver;
	private float m_fGameSpeed = 1.0f;


	public static GameManager Instance 
	{
		get 
		{
			if (m_instance == null)
			{
				container = new GameObject();  
				container.name = "GameManager";  
				m_instance = container.AddComponent(typeof(GameManager)) as GameManager;  
			}

			return m_instance;
		}
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

	// Use this for initialization
	void Start () {
		changeState (eSTATE_READY);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void changeState (eState
}
