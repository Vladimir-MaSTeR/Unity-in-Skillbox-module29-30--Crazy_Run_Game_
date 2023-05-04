using System;
using UnityEngine;
public class MovePlayer : MonoBehaviour {

    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        GameEvents.onSwipeTrue += Move;
    }

    private void Move(Vector3 vector) {
        _rigidbody.AddForce(vector, ForceMode.Impulse);
    }
}
