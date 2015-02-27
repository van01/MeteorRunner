using UnityEngine;
using System.Collections;

public class backgroundManager : MonoBehaviour {

	public float m_fSpeed = -5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform[] ts = gameObject.GetComponentsInChildren<Transform>();

		foreach (Transform t in ts) {
			if (t != null && t.gameObject != null)
			{
				Vector3 pos = t.transform.position;

				pos.x += m_fSpeed * Time.deltaTime;

				t.transform.position = pos;
			}
		}
	}
}
