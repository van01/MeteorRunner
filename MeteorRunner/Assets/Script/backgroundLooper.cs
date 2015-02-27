using UnityEngine;
using System.Collections;

public class backgroundLooper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Vector3 size = ((BoxCollider2D)collider).size;
		Vector3 position = collider.transform.position;
		Vector3 scale = collider.transform.localScale;

		position.x += size.x * scale.x * 2;

		collider.transform.position = position;
		
	}

}
