using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerProperties : MonoBehaviour {

	public GameObject m_LblPointObject;
	public GameObject m_LblExpObject;
	public GameObject m_LblSpeedLvObject;
	public GameObject m_LblUserLvObject;

	private Text m_LblPoint;
	private Text m_LblExp;
	private Text m_LblSpeedLv;
	private Text m_LblUserLv;

	// Use this for initialization
	void Start () {
		PlayerData.instance.test ();

		m_LblPoint = m_LblPointObject.GetComponent<Text>();
		m_LblExp   = m_LblExpObject.GetComponent<Text>();
		m_LblSpeedLv = m_LblSpeedLvObject.GetComponent<Text>();
		m_LblUserLv = m_LblUserLvObject.GetComponent<Text>();

		updateLabelText();

		Debug.Log( "m_LblPoint : " + m_LblPoint );
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void updateLabelText()
	{
		m_LblPoint.text = "("+PlayerData.instance.getUpPoint()+")";
		m_LblExp.text = " " + PlayerData.instance.getExp() + "/ " + PlayerData.instance.getNextLevelUpExp();
		m_LblSpeedLv.text = "Speed\nLv." + PlayerData.instance.getSpeedLevel();
		m_LblUserLv.text = "LEVEL " + (PlayerData.instance.getUserLevel() + 1);
	}

	public void onSpeedLevelUp()
	{
		PlayerData.instance.setSpeedLevelUp();
		updateLabelText();
	}


}
