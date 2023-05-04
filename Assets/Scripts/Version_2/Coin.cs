using UnityEngine;
public class Coin : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Подобрал монетку, нужно её уничтожить и отправить эвент сбора монет");
            Destroy(gameObject);
        }
    }
}
