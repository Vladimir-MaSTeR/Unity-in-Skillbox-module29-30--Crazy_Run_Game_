using UnityEngine;
public class Coin : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(GameConstants.PLAYER_TAG)) {
            // Debug.Log("�������� �������, ����� � ���������� � ��������� ����� ����� �����");
            GameEvents.onAddCoin?.Invoke();
            Destroy(gameObject);
        }
    }
}
