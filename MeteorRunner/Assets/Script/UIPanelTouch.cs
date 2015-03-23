using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIPanelTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
		GameManager.Instance.onPlayerRun (true);
	}
	
	void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
		GameManager.Instance.onPlayerRun (false);
	}
}
