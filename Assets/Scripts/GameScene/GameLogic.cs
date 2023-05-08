using System;
using System.Globalization;
using TMPro;
using UnityEngine;
public class GameLogic : MonoBehaviour {
    [SerializeField]
    [Tooltip("��������� ���������� �����")]
    private int _startCoin;

    [SerializeField]
    [Tooltip("����� ������ � ��������")]
    private float _startRoundTime = 10f;

    [Space(20)]
    [Header("��������� ����")]
    [SerializeField]
    private TMP_Text _coinText;

    [SerializeField]
    private TMP_Text _roundTimeText;

    



    private int _currentCoin;
    private float _currentRoundTime;

    private void Awake() {
        _currentCoin = _startCoin;
        _currentRoundTime = _startRoundTime;
    }

    private void FixedUpdate() {
        if(_currentRoundTime > 0) {
            UpdateTimerText(_currentRoundTime);
            UpdateCoinText(_currentCoin);
            
            _currentRoundTime -= Time.deltaTime;
            
        } else {
            Debug.Log("�� ���������");
        }
    }

    private void UpdateTimerText(float time) {
        if(time < 0) {
            time = 0;
        }
        
        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time % 60);
        _roundTimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void UpdateCoinText(int value) {
        var finaleText = $"������: {value}";
        
        _coinText.text = finaleText;
    }


    #region ������� � �������

    public int CurrentCoin { get => _currentCoin; set => _currentCoin = value; }

    public float CurrentRoundTime { get => _currentRoundTime; set => _currentRoundTime = value; }

    #endregion
}
