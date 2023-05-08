using UnityEngine;
public class Trap : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            GameEvents.onGameOver?.Invoke();
        }
    }
}
