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

	private PlayerSpeedLevelData []m_arSpeedData;

	private int 	m_nSpeedLevel 	= 0;
	private int 	m_nLevelPoint	= 0;
	private int     m_nUserLevel	= 0;
	private float 	m_fExp			= 0;

	public void Awake()
    {
    	Debug.Log ("PlayerData : Awake");
        DontDestroyOnLoad(this.gameObject);
		initData();
    }

	// Use this for initialization
	void Start () {
		Debug.Log ("PlayerData : Use this for initialization");
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
			m_arSpeedData[i].setData (i, (i+1)*10);
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
		return 7.0f+(((float)m_nSpeedLevel)/10.0f);
	}

	public void setSpeedLevelUp()
	{
		Debug.Log ("PlayerData : setSpeedLevelUp");
		if (m_nLevelPoint > 0)
		{
			m_nSpeedLevel++;
			m_nLevelPoint--;
			Debug.Log("Level Up : " + m_nSpeedLevel +  ")");
		}
	}

	public int getUpPoint()
	{
		return m_nLevelPoint;
	}

	public int getNextLevelUpExp()
	{
	//	Debug.Log ("m_arSpeedData["+m_nUserLevel+"].fExp : " + m_arSpeedData [m_nUserLevel].fExp);
		return (int)m_arSpeedData[m_nUserLevel].fExp;
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
		while (m_arSpeedData[m_nLevelPoint].fExp < m_fExp)
		{
			m_fExp -= m_arSpeedData[m_nUserLevel].fExp;
			m_nUserLevel++;
			m_nLevelPoint++;
			Debug.Log("Level Up : " + m_fExp + 
					  ", " + m_arSpeedData[m_nLevelPoint].fExp +
					  ", " + m_nLevelPoint +
					  ")");
		}
	}

}
