﻿using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public	bool m_isPlayerMove = false;
	public	float m_PlayerSpeed = 1.5f;
	private	Animator	m_anim;
	public bool m_isAlive	= true;
	private Vector3 m_vtLastPosition;
	private Vector3 m_vtMaxMove;

	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animator> ();

		m_vtMaxMove = GameObject.FindGameObjectWithTag ("Block").transform.position;
	}
	// Update is called once per frame
	void Update () {

		if (!m_isAlive || !GameManager.Instance.isIngame())
			return;

//		if (!Input.GetButton("Fire1"))
		if (!m_isPlayerMove)
		{
			m_anim.SetBool("isRun", false);
			return;
		}
		m_anim.SetBool("isRun", true);


		m_vtLastPosition = this.transform.position;
		float fScore = m_PlayerSpeed * Time.deltaTime;
		m_vtLastPosition.x += fScore;

		if (m_vtLastPosition.x > m_vtMaxMove.x)
		{
			m_vtLastPosition.x = m_vtMaxMove.x;
			fScore -= (m_vtLastPosition.x-m_vtMaxMove.x);
		}

		GameManager.Instance.addScore (fScore);

		this.transform.position = m_vtLastPosition;
	}

	public void setMove(bool isMove) {
		m_isPlayerMove = isMove;
	}

	//주인공 사망 시 게임오버 스크립트 호출 (재시도, 나가기)
	void OnDestroy()
	{

	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Bomb")
		{
			m_isAlive = false;
			m_anim.SetBool("isAlive", false);
			GameManager.Instance.changeState (GameManager.STATE.STATE_GAMEOVER);

			//주인공 사망
//			transform.parent.gameObject.AddComponent<GameOverScript> ();
		}
		else if (collider.tag == "Block")
		{

		}
	}
}
