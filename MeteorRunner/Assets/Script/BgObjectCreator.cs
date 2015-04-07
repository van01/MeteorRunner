using UnityEngine;
using System.Collections;

public class BgObjectCreator : MonoBehaviour {

	private float m_fDistance = 0.5f;
	public float m_fMinDistance = 7.0f;
	public float m_fMaxDistance = 15.0f;
	private float m_fTime = 0.0f;
	public Rigidbody2D m_copySrc1;
	public Rigidbody2D m_copySrc2;
	public Rigidbody2D m_copySrc3;
	public Rigidbody2D m_copySrc4;
	public Rigidbody2D m_copySrc5;
	public Rigidbody2D m_copySrc6;
	public Transform m_parent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.Instance.isIngame()) 
			return;

		//m_fTime += Time.deltaTime;
		float fDistance = GameManager.Instance.getScore ();

		if (m_fDistance < fDistance - m_fTime)
		{
			make();
			m_fDistance = Random.Range (m_fMinDistance, m_fMaxDistance);
			m_fTime = fDistance;
		}
	}

	void make()
	{
		Vector3 pos 	= this.transform.position;
		Vector3 scale 	= this.transform.localScale;
		float fWidth = scale.x / 2;

		pos.x += Random.Range (-fWidth, fWidth);

		Rigidbody2D rigid = null;

		switch (Random.Range (0, 6))
		{
		case 0:
			rigid = m_copySrc1;
			break;
		case 1:
			rigid = m_copySrc2;
			break;
		case 2:
			rigid = m_copySrc3;
			break;
		case 3:
			rigid = m_copySrc4;
			break;
		case 4:
			rigid = m_copySrc5;
			break;
		case 5:
			rigid = m_copySrc6;
			break;
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
