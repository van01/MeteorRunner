using UnityEngine;
using System.Collections;

public class PlayerRelativeMovement : MonoBehaviour {

	public GameObject m_player = null;
	public float m_offsetX = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = m_player.transform.position.x - m_offsetX;
		transform.position = pos;
	}
}
