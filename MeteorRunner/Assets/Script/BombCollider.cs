using UnityEngine;
using System.Collections;

public class BombCollider : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		BombObject bomb = collider.GetComponent<BombObject> ();
		bomb.onExfired ();
	}

}
