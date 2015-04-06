using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

	public float m_fSpeed = -5.0f;
	
	// Use this for initialization
	void Start () {
		m_fSpeed = -(PlayerData.instance.getSpeed () * 0.5f);
		Debug.Log ("GameSpeed : " + m_fSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform t in transform) {
			if (t != null && t.gameObject != null)
			{


				float fGameSpeed = GameManager.Instance.fGameSpeed;

				Vector3 pos = t.transform.position;
				
				pos.x += m_fSpeed * Time.deltaTime * fGameSpeed;
				
				t.transform.position = pos;
			}
		}
	}
}
