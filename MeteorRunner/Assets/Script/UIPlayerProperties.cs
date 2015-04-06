using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerProperties : MonoBehaviour {

	public GameObject m_LblPointObject;
	public GameObject m_LblExpObject;
	public GameObject m_LblSpeedLvObject;
	public GameObject m_LblUserLvObject;
	public GameObject m_LblEvadeObject;

	private Text m_LblPoint;
	private Text m_LblExp;
	private Text m_LblSpeedLv;
	private Text m_LblUserLv;
	private Text m_LblEvade;

	// Use this for initialization
	void Start () {
		PlayerData.instance.test ();

		m_LblPoint = m_LblPointObject.GetComponent<Text>();
		m_LblExp   = m_LblExpObject.GetComponent<Text>();
		m_LblSpeedLv = m_LblSpeedLvObject.GetComponent<Text>();
		m_LblUserLv = m_LblUserLvObject.GetComponent<Text>();
		m_LblEvade = m_LblEvadeObject.GetComponent<Text> ();

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
		m_LblEvade.text = "Evade\nLv." + PlayerData.instance.getEvadeLevel();

		m_LblUserLv.text = "LEVEL " + (PlayerData.instance.getUserLevel() + 1);


	}

	// click the speed button
	public void onSpeedLevelUp()
	{
		SoundEffects.instance.MakeSound_Button ();
		PlayerData.instance.setSpeedLevelUp();
		updateLabelText();
	}

	// click the evade button
	public void onEvadeUp()
	{
		SoundEffects.instance.MakeSound_Button ();
		PlayerData.instance.setEvadeLevelUp();
		updateLabelText();
	}

	public void onReset()
	{
		SoundEffects.instance.MakeSound_Button ();
		PlayerData.instance.reset ();
		updateLabelText ();
	}
}
