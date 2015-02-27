using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float CAMERA_SPEED = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;

		pos.x += (CAMERA_SPEED * Time.deltaTime);

		this.transform.position = pos;
	}
}
