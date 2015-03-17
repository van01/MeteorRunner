using UnityEngine;
using System.Collections;

public class UIPositionCoodinator : MonoBehaviour {

	public enum Anchor
	{
		TOP			= 0x01,
		BOTTOM		= 0x02,
		LEFT		= 0x04,
		RIGHT		= 0x08,
		CENTER		= 0x10,
		TOPLEFT		= TOP|LEFT,
		TOPRIGHT	= TOP|RIGHT,
		BOTTOMLEFT	= BOTTOM|LEFT,
		BOTTOMRIGHT = BOTTOM|RIGHT,
	}

	public Anchor m_anchor = Anchor.CENTER;


	void Start()
	{
		RectTransform rectTransform = (RectTransform)transform;

		rectTransform.position = new Vector3 (0, 0, 0);

	}

	void OnGUI()
	{
	}
}
