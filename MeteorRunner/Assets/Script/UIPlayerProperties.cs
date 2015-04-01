using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerProperties : MonoBehaviour {

	public GameObject m_LblPointObject;
	public GameObject m_LblExpObject;
	
	private Text m_LblPoint;
	private Text m_LblExp;
	


	// Use this for initialization
	void Start () {
		PlayerData.instance.test ();

		m_LblPoint = m_LblPointObject.GetComponent<Text>();
		m_LblExp   = m_LblExpObject.GetComponent<Text>();

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
	}

	public void onSpeedLevelUp()
	{
		PlayerData.instance.setSpeedLevelUp();
		updateLabelText();
	}


}
