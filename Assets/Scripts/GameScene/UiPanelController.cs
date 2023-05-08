using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiPanelController : MonoBehaviour {
    [Header("������")]
    [SerializeField]
    private GameObject _pausedPanel;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private GameObject _finishPanel;

    [Space(20)]
    [Header("�����")]
    
    [SerializeField]
    private TMP_Text _coinTextFromGameOverPanel;
    
    [SerializeField]
    private TMP_Text _coinTextFromFinishPanel;

    private void Awake() {
        _pausedPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _finishPanel.SetActive(false);
    }

    private void OnEnable() {
        GameEvents.onGameOver += GameOver;
        GameEvents.onFinish += Finish;
    }

    private void OnDisable() {
        GameEvents.onGameOver -= GameOver;
        GameEvents.onFinish -= Finish;
    }

    public void BackInMenuScene() {
        int coin = (int)GameEvents.onGetCoin?.Invoke();
        Dictionary<string, int> saveDictionary = new Dictionary<string, int>();
        saveDictionary.Add(GameConstants.COIN_KEY, coin);
        
        //��� ����� ����� ������ ��� ����������
        
        SavePlayerPrefsInt(saveDictionary);
        SceneManager.LoadScene(GameConstants.MENU_SCENE_INDEX);
    }
    
    public void ReloadGameScene() {
        SceneManager.LoadScene(GameConstants.GAME_SCENE_INDEX);
    }
    
    private void SavePlayerPrefsInt(Dictionary<string, int> dictionary) {
        foreach(var VARIABLE in dictionary) {
            PlayerPrefs.SetInt(VARIABLE.Key, VARIABLE.Value);
            PlayerPrefs.Save();
        }
    }

    #region ������ �����

    public void ActivePaused() {
        GameEvents.onPaused?.Invoke(true);
        _pausedPanel.SetActive(true);
    }

    public void BackInGameFromPausedPanel() {
        _pausedPanel.SetActive(false);
        GameEvents.onPaused?.Invoke(false);
        //��������� ����� ��������� �����
    }

    #endregion

    #region ������ ���������

    public void GameOver() {
        GameEvents.onPaused?.Invoke(true);
        _gameOverPanel.SetActive(true);
        
        var coin = GameEvents.onGetCoin?.Invoke();
        var coinText = $"������:\n{coin}";
        _coinTextFromGameOverPanel.text = coinText;
    }

    #endregion

    #region ������ ��������

    public void Finish() {
        GameEvents.onPaused?.Invoke(true);
        _finishPanel.SetActive(true);
        
        var coin = GameEvents.onGetCoin?.Invoke();
        var coinText = $"������:\n{coin}";
        _coinTextFromFinishPanel.text = coinText;
    }

    #endregion
}
