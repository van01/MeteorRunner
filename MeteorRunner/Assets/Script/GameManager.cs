using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static string HIGHSCORE = "HighScore";

	private static GameObject container;  
	private static GameManager m_instance = null;
	private bool 				m_isGameOver;
	private float 				m_fGameSpeed 	= 1.0f;
	private float 				m_fScore 		= 0.0f;
	private float				m_fHighScore 	= 0.0f;

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
		m_fHighScore = PlayerPrefs.GetFloat (HIGHSCORE, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
