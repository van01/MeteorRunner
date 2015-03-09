using UnityEngine;
using System.Collections;

public class BombObject : MonoBehaviour {

	bool m_isFired = false;
	public float m_fAddSpeed = 0.0f;
	public float m_fDamege = 0.0f;

	void Start()
	{
	}

	public void onExfired()
	{
		Animator anim = GetComponent<Animator> ();
		anim.SetBool ("isExfired", true);

		this.gameObject.rigidbody2D.isKinematic = true;
		m_isFired = true;
	}

	public void disableCollider()
	{
		this.gameObject.collider2D.enabled = false;
	}

	public void destroyBomb()
	{
		Destroy (this.gameObject);
	}

	public void Update()
	{
		if (!m_isFired)
		{
			Vector3 pos = this.gameObject.transform.position;

			pos.x += m_fAddSpeed * Time.deltaTime;

			this.gameObject.transform.position = pos;
		}
	}
}
