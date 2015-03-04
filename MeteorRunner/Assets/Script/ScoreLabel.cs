﻿using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {

	private string 				m_FrontText = "Dist : ";
	private GUIText 			m_GuiScore;


	// Use this for initialization
	void Start () {
		m_GuiScore = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		float fScore = GameManager.Instance.getScore ();
		m_GuiScore.text = m_FrontText + fScore.ToString ("N2");
	}
}
