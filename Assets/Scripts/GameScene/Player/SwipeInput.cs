using UnityEngine;
using UnityEngine.EventSystems;
public class SwipeInput : MonoBehaviour, IDragHandler, IBeginDragHandler {
    private bool _paused = false;

    private void OnEnable() { GameEvents.onPaused += SetPausedEvent; }
    private void OnDisable() { GameEvents.onPaused -= SetPausedEvent; }

    public void OnDrag(PointerEventData eventData) { }
    public void OnBeginDrag(PointerEventData eventData) {
        if(!_paused) {
            if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)) {
                if(eventData.delta.x > 0) {
                    GameEvents.onSwipeTrue?.Invoke(new Vector3(eventData.delta.x, 0, 0));
                    // Debug.Log("Свайп в право");
                } else {
                    GameEvents.onSwipeTrue?.Invoke(new Vector3(eventData.delta.x, 0, 0));
                    // Debug.Log("Свайп в лево");
                }
            } else {
                if(eventData.delta.y > 0) {
                    GameEvents.onSwipeTrue?.Invoke(new Vector3(0, 0, eventData.delta.y));
                    // Debug.Log("Свайп в верх");
                } else {
                    GameEvents.onSwipeTrue?.Invoke(new Vector3(0, 0, eventData.delta.y));
                    // Debug.Log("Свайп в низ");
                }
            }
        }
    }

    private void SetPausedEvent(bool value) { _paused = value; }
}
