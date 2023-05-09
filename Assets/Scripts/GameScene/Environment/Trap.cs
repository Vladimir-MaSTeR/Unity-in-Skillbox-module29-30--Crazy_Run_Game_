using UnityEngine;
public class Trap : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(GameConstants.PLAYER_TAG)) {
            GameEvents.onGameOver?.Invoke();
        }
    }
}
