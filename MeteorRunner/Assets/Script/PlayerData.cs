using UnityEngine;
using System.Collections;

public class PlayerData : Singleton<PlayerData> {

	class PlayerSpeedLevelData {
		public int 		nLevel;
		public float  	fExp;

		public void setData (int level, float exp)
		{
			nLevel = level;
			fExp = exp;
		}
	}
	private static float m_fDefaultSpeed = 7.0f;
	private static float m_fDefaultEvadeDelayTime = 30.0f;

	private PlayerSpeedLevelData []m_arSpeedData;

	private int 	m_nSpeedLevel 	= 0;
	private int 	m_nUserPoint	= 0;
	private int     m_nUserLevel	= 0;
	private int		m_nEvadeLevel	= 0;
	private float 	m_fExp			= 0;

	public void Awake()
    {
    	Debug.Log ("PlayerData : Awake");
        DontDestroyOnLoad(this.gameObject);
		initData();

		load ();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initData()
	{
		m_arSpeedData = new PlayerSpeedLevelData[100];

		for (int i=0; i<m_arSpeedData.Length; i++)
		{
			m_arSpeedData[i] = new PlayerSpeedLevelData();
//			m_arSpeedData[i].setData (i, (i+1)*10);
			m_arSpeedData[i].setData (i, 1);
		}
	}

	public void setExp (float fExp) {
		m_fExp += fExp;
	}

	public int getExp()
	{
		return (int)m_fExp;
	}


	public float getSpeed ()
	{
		//return 7.0f+(((float)m_nSpeedLevel)/10.0f);

		float fSpeed = m_fDefaultSpeed;

		for (int i=0; i<m_nSpeedLevel; i++)
		{
			fSpeed += (fSpeed * 0.05f);
		}

		Debug.Log ("game speed : " + fSpeed);

		return fSpeed;
	}

	public void setSpeedLevelUp()
	{
		if (m_nUserPoint > 0)
		{
			m_nSpeedLevel++;
			m_nUserPoint--;
			Debug.Log("Level Up : " + m_nSpeedLevel);
			save ();
		}
	}

	public void setEvadeLevelUp()
	{
		if (m_nUserPoint > 0)
		{
			m_nEvadeLevel++;
			m_nUserPoint--;
			Debug.Log("Evade Level : " + m_nEvadeLevel);
			save ();
		}
	}

	public int getUpPoint()
	{
		return m_nUserPoint;
	}

	public int getNextLevelUpExp()
	{
	//	Debug.Log ("m_arSpeedData["+m_nUserLevel+"].fExp : " + m_arSpeedData [m_nUserLevel].fExp);
		return (int)m_arSpeedData[m_nUserLevel].fExp;
	}

	public float getEvadeLevelTime()
	{
		float nDelayTimePerPoint = (m_fDefaultEvadeDelayTime * 0.05f);
		float fDelayTime = m_fDefaultEvadeDelayTime - (nDelayTimePerPoint * m_nEvadeLevel);

		if (fDelayTime < 0)
		{
			fDelayTime = 0.0f;
		}

		return fDelayTime;
	}
	
	public int getEvadeLevel()
	{
		return m_nEvadeLevel;
	}

	public int getSpeedLevel()
	{
		return m_nSpeedLevel;
	}

	public int getUserLevel()
	{
		return m_nUserLevel;
	}

	public void test()
	{
		while (m_nUserLevel <100 && 
		       m_arSpeedData[m_nUserLevel].fExp < m_fExp)
		{
			m_fExp -= m_arSpeedData[m_nUserLevel].fExp;
			Debug.Log("Level Up : " + m_fExp + 
			          ", " + m_arSpeedData[m_nUserLevel].fExp +
			          ", " + m_nUserPoint +
					  ")");
			m_nUserLevel++;
			m_nUserPoint++;
		}

		if (m_nUserLevel >= 100) 
		{
			m_nUserLevel = 99;
		}

		save ();
	}

	public void save()
	{
		Debug.Log ("save");

		PlayerPrefs.SetInt ("UserLevel", m_nUserLevel);
		PlayerPrefs.SetInt ("SpeedLevel", m_nSpeedLevel);
		PlayerPrefs.SetInt ("EvadeLevel", m_nEvadeLevel);
		PlayerPrefs.SetInt ("UserPoint", m_nUserPoint);
		PlayerPrefs.SetFloat ("Exp", m_fExp);
	}

	public void load()
	{
		Debug.Log ("Load");

		m_nUserLevel = PlayerPrefs.GetInt ("UserLevel");
		m_nSpeedLevel = PlayerPrefs.GetInt ("SpeedLevel");
		m_nEvadeLevel = PlayerPrefs.GetInt ("EvadeLevel");
		m_nUserPoint = PlayerPrefs.GetInt ("UserPoint");
		m_fExp = PlayerPrefs.GetFloat ("Exp");

	}

	public void reset()
	{
		Debug.Log ("Load");
		
		PlayerPrefs.SetInt ("UserLevel", 0);
		PlayerPrefs.SetInt ("SpeedLevel", 0);
		PlayerPrefs.SetInt ("EvadeLevel", 0);
		PlayerPrefs.SetInt ("UserPoint", 0);
		PlayerPrefs.SetFloat ("Exp", 0);

		load ();
		
	}

}
