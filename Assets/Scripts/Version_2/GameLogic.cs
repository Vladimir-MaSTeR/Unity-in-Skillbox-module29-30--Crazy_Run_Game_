using UnityEngine;
public class GameLogic : MonoBehaviour {
    [SerializeField]
    [Tooltip("��������� ���������� �����")]
    private int _startCoin;

    [SerializeField]
    [Tooltip("����� ������ � �������")]
    private float _startRoundTime = 1f;


    private int _currentCoin;
    private float _currentRoundTime;

    private void Awake() {
        _currentCoin = _startCoin;
        _currentRoundTime = _startRoundTime;
    }

    #region ������� � �������

    public int CurrentCoin {get => _currentCoin;set => _currentCoin = value;}

    public float CurrentRoundTime {get => _currentRoundTime;set => _currentRoundTime = value;}

    #endregion
}
