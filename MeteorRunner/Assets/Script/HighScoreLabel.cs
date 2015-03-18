using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreLabel : MonoBehaviour {

	private string 				m_FrontText = "High : ";
	private Text 				m_GuiScore;

	// Use this for initialization
	void Start () {
		m_GuiScore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		float fScore = GameManager.Instance.getHighScore ();
		m_GuiScore.text = m_FrontText + fScore.ToString ("N2");
	}
}
