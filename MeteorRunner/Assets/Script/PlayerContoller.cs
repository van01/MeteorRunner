using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {


	private static float MAX_ENERGY = 100.0f;

	public enum STATE
	{
		STOP		= 0,
		RUN			= 1,
		BACKSTEP	= 2,
		NOCKDOWN	= 3,
		DEAD		= 4,
	}

	private enum SUBSTATE
	{
		NORMAL		= 0,
		CRASH		= 1,
	}

	private STATE 		m_nState = STATE.STOP;
	private SUBSTATE	m_nSubState = SUBSTATE.NORMAL;

	//sub state
	private bool		m_isBackStepMove = false;


	private SpriteRenderer	m_spRender		= null;
	private Material		m_MaterialNormal = null;
	public  Material		m_MaterialWhite = null;
	public float 		m_PlayerSpeed 		= 1.5f;
	public float		m_BackStepSpeed 	= -20.0f;
	private	Animator	m_anim;
	private Vector3 	m_vtLastPosition;
	private Vector3 	m_vtMaxMove;
	private bool		m_isPressedRun = false;
	private float		m_fEnergy			= MAX_ENERGY;


	// Use this for initialization
	void Start () {
		m_anim 		= GetComponent<Animator> ();
		m_spRender = GetComponent<SpriteRenderer> ();
		m_MaterialNormal = m_spRender.material;
//		m_MaterialWhite = Resources.Load<Material> ("Font Material") as Material;

		m_vtMaxMove = GameObject.FindGameObjectWithTag ("Block").transform.position;
	}

	/****************************************************
	 * update Function
	 ****************************************************/

	// Update is called once per frame
	void Update () {

		if (!GameManager.Instance.isIngame())
			return;


		switch (m_nState)
		{
		case STATE.RUN:
			calcRunPosition();
			updateRun();
			break;
		case STATE.BACKSTEP:
			calcBackStepPosition();
			break;
		}


	}

	static float	FLICKER_PLAYER_TIME 	= 1.0f;
	static float	FLICKER_PLAYER_DELAY 	= 0.1f;
	float			m_fFlickerTime 	= 0.0f;
	float 			m_fFlickerTotalTime = 0.0f;
	bool			m_isFlickerNormal = true;
	void updateRun()
	{
		if (m_nSubState == SUBSTATE.CRASH)
		{
			m_fFlickerTotalTime += Time.deltaTime;

			if (m_fFlickerTotalTime > FLICKER_PLAYER_TIME)
			{
				setSubState (SUBSTATE.NORMAL);
			}
			else
			{
				m_fFlickerTime += Time.deltaTime;

				Debug.Log (m_fFlickerTime + ", " + FLICKER_PLAYER_DELAY);
				if (m_fFlickerTime > FLICKER_PLAYER_DELAY)
				{
					if (m_isFlickerNormal)
					{
						Debug.Log ("White");
						m_spRender.material = m_MaterialWhite;
					}
					else
					{
						Debug.Log ("normal");
						m_spRender.material = m_MaterialNormal;
					}
					m_isFlickerNormal = !m_isFlickerNormal;
					m_fFlickerTime = 0;
				}
			}

		}
	}

	/****************************************************
	 * Collider check
	 ****************************************************/


	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Bomb" && m_nState != STATE.BACKSTEP && m_nSubState != SUBSTATE.CRASH)
		{
			BombObject bomb = collider.GetComponent<BombObject>();

			m_fEnergy -= bomb.m_fDamege;

			if (m_fEnergy <= 0.0f)
			{
				m_fEnergy = 0.0f;
				setState (STATE.NOCKDOWN);
				GameManager.Instance.changeState (GameManager.STATE.STATE_GAMEOVER);
			}
			else
			{
				setSubState (SUBSTATE.CRASH);
			}
		}
		else if (collider.tag == "Block")
		{

		}
	}

	public float getEnergy()
	{
		return m_fEnergy;
	}

	void setState (STATE state)
	{
		Debug.Log ("STATE Start: " + state +" -> " + m_nState);

		STATE prevState = m_nState;
		switch (state)
		{
		case STATE.STOP:
			if (m_nState != STATE.NOCKDOWN)
			{
				m_nState = state;
			}
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

		if (prevState != m_nState)
		{
			setSubState (SUBSTATE.NORMAL);
		}

		m_anim.SetInteger ("STATE", (int)m_nState);

		Debug.Log ("STATE End : " + m_nState);
	}

	void setSubState (SUBSTATE subState)
	{
		Debug.Log ("SubState " + m_nSubState + " -> "+ subState);
		switch (m_nSubState)
		{
		case SUBSTATE.CRASH:
			m_spRender.material = m_MaterialNormal;
			break;
		}

		switch (subState)
		{
		case SUBSTATE.CRASH:
			m_fFlickerTime = 0.0f;
			m_fFlickerTotalTime = 0.0f;
			m_isFlickerNormal = false;
			m_spRender.material = m_MaterialWhite;
			break;
		}
		m_nSubState = subState;
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
