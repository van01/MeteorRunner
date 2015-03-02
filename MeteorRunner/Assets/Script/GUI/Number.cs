using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {

	public Texture m_Texture = null;

	void OnGUI()
	{
		if (!m_Texture) {
			Debug.LogError ("Assign a Texture in the inspector ");
			return;
		}
		GUI.DrawTexture (new Rect (0, 0, 100, 100), m_Texture, ScaleMode.ScaleToFit, true, 10.0f);
	}
}
