using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	enum STATE
	{
		RUN,
		BACK,
		WAIT,
	}
	private static float MAX_POSITION_X = 0.0f;

	public float m_fSpeed = 5.0f;
	private float m_fTargetX;
	private STATE m_state = STATE.WAIT;
	private Vector3 m_orgPosition;

	// Use this for initialization
	void Start () {
		m_orgPosition = transform.position;
		start (10);
	}
	
	// Update is called once per frame
	void Update () {

		switch (GameManager.Instance.getState ())
		{
		case GameManager.STATE.STATE_GAME:
			move();
			break;
		}
	}

	void move()
	{
		if (m_state == STATE.RUN)
		{
			Vector3 pos = transform.position;
			pos.x += m_fSpeed * Time.deltaTime;
			transform.position = pos;

			if (m_fTargetX < pos.x )
			{
				changeState (STATE.BACK);
			}
		}
		else if (m_state == STATE.BACK)
		{
			Vector3 pos = transform.position;
			pos.x -= m_fSpeed * Time.deltaTime;

			if (m_orgPosition.x < pos.x)
			{
				transform.position = pos;
			}
			else 
			{
				changeState (STATE.WAIT);
				transform.position = m_orgPosition;
			}
		}
	}

	void changeState (STATE state)
	{
		Debug.Log ("Monster State Change " + m_state + " ->> " + state);
		m_state = state;
	}

	public void start(float distance)
	{
		if (m_state == STATE.WAIT)
		{
			m_fTargetX = m_orgPosition.x + distance;
			if (m_fTargetX > MAX_POSITION_X)
			{
				m_fTargetX = MAX_POSITION_X;
			}
			changeState (STATE.RUN);
		}
	}
}
