using UnityEngine;
using System.Collections;

public class HighScoreLabel : MonoBehaviour {

	private string 				m_FrontText = "High : ";
	private GUIText 			m_GuiScore;

	// Use this for initialization
	void Start () {
		m_GuiScore = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		float fScore = GameManager.Instance.getHighScore ();
		m_GuiScore.text = m_FrontText + fScore.ToString ("N2");
	}
}
