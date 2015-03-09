using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {

	private string 				m_FrontText = "Dist : ";
	private GUIText 			m_GuiScore;


	// Use this for initialization
	void Start () {

		m_GuiScore = GetComponent<GUIText> ();

		//this.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);//(10f / (float)Screen.width, 10f / (float)Screen.height, 0f);
		//m_GuiScore.pixelOffset = new Vector3 (10f / (float)Screen.width, 10f / (float)Screen.height, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		float fScore = GameManager.Instance.getScore ();
		m_GuiScore.text = m_FrontText + fScore.ToString ("N2");
	}

	void OnGUI()
	{

	}
}
