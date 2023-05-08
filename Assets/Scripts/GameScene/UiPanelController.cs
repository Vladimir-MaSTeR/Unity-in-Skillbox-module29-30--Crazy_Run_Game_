using System;
using UnityEngine;
public class UiPanelController : MonoBehaviour {
    
    [Header("������")]
    [SerializeField]
    private GameObject _pausedPanel;
    
    [SerializeField]
    private GameObject _gameOverPanel;
    
    [SerializeField]
    private GameObject _finishPanel;

    private void Awake() {
        _pausedPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _finishPanel.SetActive(false);
    }


    public void ActivePaused() {
        //��������� ����� ��������� �����
        _pausedPanel.SetActive(true);
    }
    
    public void BackInGameFromPausedPanel() {
        _pausedPanel.SetActive(false);
        //��������� ����� ��������� �����
    }
}
