using UnityEngine;
public class Coin : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(GameConstants.PLAYER_TAG)) {
            // Debug.Log("Подобрал монетку, нужно её уничтожить и отправить эвент сбора монет");
            GameEvents.onAddCoin?.Invoke();
            Destroy(gameObject);
        }
    }
}
