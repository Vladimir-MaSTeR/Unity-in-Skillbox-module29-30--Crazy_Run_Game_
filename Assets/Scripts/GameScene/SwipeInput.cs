using UnityEngine;
using UnityEngine.EventSystems;
public class SwipeInput : MonoBehaviour, IDragHandler, IBeginDragHandler {
    
    public void OnDrag(PointerEventData eventData) {
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)) {
            if(eventData.delta.x > 0) {
                GameEvents.onSwipeTrue?.Invoke(new Vector3(eventData.delta.x, 0, 0));
                // Debug.Log("����� � �����");
            } else {
                GameEvents.onSwipeTrue?.Invoke(new Vector3(eventData.delta.x, 0, 0));
                // Debug.Log("����� � ����");
            }
        } else {
            if(eventData.delta.y > 0) {
                GameEvents.onSwipeTrue?.Invoke(new Vector3(0, 0, eventData.delta.y));
                // Debug.Log("����� � ����");
            } else {
                GameEvents.onSwipeTrue?.Invoke(new Vector3(0, 0, eventData.delta.y));
                // Debug.Log("����� � ���");
            }
        }
    }
}
