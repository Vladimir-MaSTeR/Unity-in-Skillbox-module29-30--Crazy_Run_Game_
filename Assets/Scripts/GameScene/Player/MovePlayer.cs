using UnityEngine;
public class MovePlayer : MonoBehaviour {
    private Rigidbody _rigidbody;
    private bool _paused = false;

    private void Awake() { _rigidbody = GetComponent<Rigidbody>(); }

    private void OnEnable() {
        GameEvents.onSwipeTrue += Move;
        GameEvents.onPaused += CheckPaused;
    }

    private void OnDisable() {
        GameEvents.onSwipeTrue -= Move; 
        GameEvents.onPaused -= CheckPaused;
    }

    private void Move(Vector3 vector) {
        
        if(!_paused) {
            _rigidbody.AddForce(vector, ForceMode.Force);
        } 
    }

    private void CheckPaused(bool value) {
        _paused = value;
        
        if(_paused) {
           _rigidbody.velocity = Vector3.zero;
           _rigidbody.angularVelocity = Vector3.zero;
        } 
    }
}
