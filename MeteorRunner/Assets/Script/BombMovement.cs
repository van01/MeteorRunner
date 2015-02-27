using UnityEngine;
using System.Collections;

public class BombMovement : MonoBehaviour {

	public float m_fDropSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		pos.y -= m_fDropSpeed * Time.deltaTime;

		transform.position = pos;
	}
}
