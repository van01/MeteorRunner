using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerProperties : MonoBehaviour {
	
	public GameObject m_LblPointObject;
	public GameObject m_LblUserLvObject;
	public GameObject m_LblExpObject;
	public Slider	  m_SliderExp;

	public GameObject m_LblSpeedLvObject;
	public GameObject m_LblBoosterLvObject;
	public GameObject m_LblEvadeLvObject;
	public GameObject m_LblSkillText;

	public GameObject m_ButtonLevelUp;

	private Text m_LblPoint;
	private Text m_LblUserLv;
	private Text m_LblExp;

	private Text m_LblSpeedLv;
	private Text m_LblBoosterLv;
	private Text m_LblEvadeLv;
	private Text m_LblSkill;

	private enum ActiveSkill{
		SPEED,
		BOOSTER,
		EVADE,
	}

	private ActiveSkill state;

	// Use this for initialization
	void Start () {
		PlayerData.instance.test ();
		state = ActiveSkill.SPEED;

		m_ButtonLevelUp.SetActive (false);	

		m_LblPoint = m_LblPointObject.GetComponent<Text>();
		m_LblUserLv = m_LblUserLvObject.GetComponent<Text>();
		m_LblExp   = m_LblExpObject.GetComponent<Text>();

		m_LblSpeedLv = m_LblSpeedLvObject.GetComponent<Text>();
		m_LblBoosterLv = m_LblBoosterLvObject.GetComponent<Text>();
		m_LblEvadeLv = m_LblEvadeLvObject.GetComponent<Text>();
		m_LblSkill = m_LblSkillText.GetComponent<Text>();

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
		m_SliderExp.value = (float)PlayerData.instance.getExp() / (float)PlayerData.instance.getNextLevelUpExp();

		m_LblSpeedLv.text = "Speed\nLv." + PlayerData.instance.getSpeedLevel();
		m_LblBoosterLv.text = "Booster\nLv.0";
		m_LblEvadeLv.text = "Evade\nLv." + PlayerData.instance.getEvadeLevel();

		m_LblUserLv.text = "LEVEL " + (PlayerData.instance.getUserLevel() + 1);

		switch (state)
		{
		case ActiveSkill.SPEED:
			m_LblSkill.text = "스피드 스킬 활성화";
			break;
		case ActiveSkill.BOOSTER:
			m_LblSkill.text = "부스터 스킬 활성화";
			break;
		case ActiveSkill.EVADE:
			m_LblSkill.text = "회피 스킬 활성화";
			break;
		}

		//포인트가 있으면 레벨업 버튼을 표시하자!
		if (PlayerData.instance.getUpPoint () > 0) {
			m_ButtonLevelUp.SetActive (true);
		}
		else{
			m_ButtonLevelUp.SetActive (false);
		}
	}

	// click the speed button
	public void onSpeed()
	{
		state = ActiveSkill.SPEED;

		SoundEffects.instance.MakeSound_Button ();
		//PlayerData.instance.setSpeedLevelUp();
		updateLabelText();
	}

	// click the evade button
	public void onBooster()
	{
		state = ActiveSkill.BOOSTER;
		
		SoundEffects.instance.MakeSound_Button ();
		//PlayerData.instance.setEvadeLevelUp();
		updateLabelText();
	}

	// click the evade button
	public void onEvade()
	{
		state = ActiveSkill.EVADE;

		SoundEffects.instance.MakeSound_Button ();
		//PlayerData.instance.setEvadeLevelUp();
		updateLabelText();
	}

	public void onLevelUp()
	{
		switch (state)
		{
		case ActiveSkill.SPEED:
			PlayerData.instance.setSpeedLevelUp();
			break;
		case ActiveSkill.BOOSTER:
			//PlayerData.instance.setEvadeLevelUp();
			break;
		case ActiveSkill.EVADE:
			PlayerData.instance.setEvadeLevelUp();
			break;
		}
		SoundEffects.instance.MakeSound_Button ();
		updateLabelText();
	}

	public void onReset()
	{

		SoundEffects.instance.MakeSound_Button ();
		PlayerData.instance.reset ();
		updateLabelText ();
	}
}
