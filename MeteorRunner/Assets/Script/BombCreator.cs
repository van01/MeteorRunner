using UnityEngine;
using System.Collections;

public class BombCreator : MonoBehaviour {

	public float m_fDelayTime = 0.5f;
	private float m_fTime = 0.0f;
	public Rigidbody2D m_copySrc1;
	public Rigidbody2D m_copySrc2;
	public Transform m_parent;

	// Use this for initialization
	void Start () {

		if (m_copySrc1 == null)
			m_copySrc1 = m_copySrc2;
		if (m_copySrc2 == null)
			m_copySrc2 = m_copySrc1;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.Instance.isIngame()) 
			return;

		m_fTime += Time.deltaTime;

		if (m_fDelayTime < m_fTime)
		{
			m_fTime = 0.0f;

			makeBomb();
		}
	}

	void makeBomb()
	{
		Vector3 pos 	= this.transform.position;
		Vector3 scale 	= this.transform.localScale;
		float fWidth = scale.x / 2;

		pos.x += Random.Range (-fWidth, fWidth);

		Rigidbody2D rigid;

		if (Random.Range (0, 2) == 0)
		{
			rigid = m_copySrc2;
		}
		else
		{
			rigid = m_copySrc1;
		}

		if (rigid)
		{
			Rigidbody2D cloneObject = (Rigidbody2D)Instantiate (rigid,
		                     								pos,
		                                                    rigid.transform.rotation);
			cloneObject.transform.parent = m_parent;
		}
	}
}
