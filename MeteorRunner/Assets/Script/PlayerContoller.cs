using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public enum STATE
	{
		STOP		= 0,
		RUN			= 1,
		BACKSTEP	= 2,
		NOCKDOWN	= 3,
		DEAD		= 4,
	}

	private STATE 		m_nState = STATE.STOP;

	//sub state
	private bool		m_isBackStepMove = false;

	public float 		m_PlayerSpeed 		= 1.5f;
	public float		m_BackStepSpeed 	= -20.0f;
	private	Animator	m_anim;
	private Vector3 	m_vtLastPosition;
	private Vector3 	m_vtMaxMove;
	private bool		m_isPressedRun = false;


	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animator> ();

		m_vtMaxMove = GameObject.FindGameObjectWithTag ("Block").transform.position;
	}
	// Update is called once per frame
	void Update () {

		if (!GameManager.Instance.isIngame())
			return;


		switch (m_nState)
		{
		case STATE.RUN:
			calcRunPosition();
			break;
		case STATE.BACKSTEP:
			calcBackStepPosition();
			break;
		}


	}



	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Bomb")
		{
			setState (STATE.NOCKDOWN);

			GameManager.Instance.changeState (GameManager.STATE.STATE_GAMEOVER);

			//주인공 사망
//			transform.parent.gameObject.AddComponent<GameOverScript> ();
		}
		else if (collider.tag == "Block")
		{

		}
	}

	void setState (STATE state)
	{
		Debug.Log ("STATE Start: " + state +" -> " + m_nState);

		switch (state)
		{
		case STATE.STOP:
			if (m_nState != STATE.NOCKDOWN)
				m_nState = state;
			break;
		case STATE.RUN:
			if (m_nState != STATE.NOCKDOWN)
				m_nState = state;
			break;
		case STATE.BACKSTEP:
			if (m_nState != STATE.NOCKDOWN)
				m_nState = state;
			break;
		case STATE.NOCKDOWN:
			m_nState = state;
			break;
		}

		m_anim.SetInteger ("STATE", (int)m_nState);

		Debug.Log ("STATE End : " + m_nState);
	}

	/****************************************************
	 * position calcuration
	 ****************************************************/
	float calcPosition (float fSpeed)
	{
		m_vtLastPosition = this.transform.position;
		float fScore = fSpeed * Time.deltaTime;
		m_vtLastPosition.x += fScore;
		
		if (m_vtLastPosition.x > m_vtMaxMove.x)
		{
			m_vtLastPosition.x = m_vtMaxMove.x;
			fScore -= (m_vtLastPosition.x-m_vtMaxMove.x);
		}

		this.transform.position = m_vtLastPosition;

		return fScore;
	}

	void calcRunPosition()
	{
		float fScore = calcPosition (m_PlayerSpeed);
		
		GameManager.Instance.addScore (fScore);
		
	}

	void calcBackStepPosition()
	{
		if (m_isBackStepMove)
			calcPosition (m_BackStepSpeed);
	}

	/****************************************************
	 * animation event
	 ****************************************************/
	public void BackStep_StartMove()
	{
		m_isBackStepMove = true;
	}
	public void BackStep_AniEnd()
	{
		if (m_isPressedRun)
		{
			setState (STATE.RUN);
		}
		else
		{
			setState (STATE.STOP);
		}

		m_isBackStepMove = false;
	}

	/****************************************************
	 * Player Control Function
	 ****************************************************/

	public void setMove(bool isMove) {

		m_isPressedRun = isMove;
		if (m_nState == STATE.BACKSTEP)
			return;
		
		if (isMove)
		{
			setState (STATE.RUN);
		}
		else
		{
			setState (STATE.STOP);
		}
		m_anim.SetInteger("STATE", (int)m_nState);
	}

	public void skill (int nSkil)
	{
		setState (STATE.BACKSTEP);

		m_anim.SetInteger("STATE", (int)m_nState);
	}

}
