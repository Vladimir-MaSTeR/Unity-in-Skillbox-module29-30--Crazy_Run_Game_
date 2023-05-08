using UnityEngine;
public class FinishGame : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("‘»Õ»ÿ");
            GameEvents.onFinish?.Invoke();
        }
    }
}
