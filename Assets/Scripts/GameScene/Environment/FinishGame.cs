using UnityEngine;
public class FinishGame : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(GameConstants.PLAYER_TAG)) {
            // Debug.Log("�����");
            GameEvents.onFinish?.Invoke();
        }
    }
}
