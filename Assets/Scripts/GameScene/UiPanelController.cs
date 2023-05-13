using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiPanelController : MonoBehaviour {
    [Header("Панели")]
    [SerializeField]
    private GameObject _pausedPanel;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private GameObject _finishPanel;

    [Space(20)]
    [Header("Текстовые панели для финиша")]
    [SerializeField]
    private TMP_Text _coinInRoundTextFromFinishPanel;

    [SerializeField]
    private TMP_Text _allCoinTextFromFinishPanel;
    
    [SerializeField]
    private TMP_Text _passedRoundsTextFromFinishPanel;
    
    [Space(20)]
    [Header("Текстовые панели для проигрыша")]
    
    [SerializeField]
    private TMP_Text _coinTextFromGameOverPanel;
    
    [SerializeField]
    private TMP_Text _allCoinTextFromGameOverPanel;
    
    [SerializeField]
    private TMP_Text _passedRoundsTextFromGameOverPanel;

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

    public void BackInMenuScene() { SceneManager.LoadScene(GameConstants.MENU_SCENE_INDEX); }

    public void ReloadGameScene() { SceneManager.LoadScene(GameConstants.GAME_SCENE_INDEX); }

    #region ПАНЕЛЬ ПАУЗЫ

    public void ActivePaused() {
        GameEvents.onPaused?.Invoke(true);
        _pausedPanel.SetActive(true);
    }

    public void BackInGameFromPausedPanel() {
        GameEvents.onPaused?.Invoke(false);
        _pausedPanel.SetActive(false);
    }

    #endregion

    #region ПАНЕЛЬ ПРОИГРЫША

    public void GameOver() {
        GameEvents.onPaused?.Invoke(true);
        _gameOverPanel.SetActive(true);

        var coin = GameEvents.onGetCoin?.Invoke();
        var coinText = $"Монеты:\n{coin}";
        _coinTextFromGameOverPanel.text = coinText;
        
        int session = (int)GameEvents.onGetSession?.Invoke();
        
        int allCoinInSession = ReloadAllCoin(session, (int)coin);
        var allCoinText = $"Монеты за все пройденные лабиринты:\n{allCoinInSession}";
        _allCoinTextFromGameOverPanel.text = allCoinText;
        // Debug.Log($"МОНЕТЫ ЗА ВСЕ РАУНДЫ В СЕССИИ = {allCoinInSession}");

        var passedRounds = ReloadPassedRounds(session) - 1;
        var passedRoundsText = $"Пройденные лабиринты:\n{passedRounds}";
        _passedRoundsTextFromGameOverPanel.text = passedRoundsText;
        // Debug.Log($"ОБЩЕЕ КОЛЛИЧЕСТВО ПРОЙДЕННЫХ РАУНДОВ = {passedRounds}");
    }

    #endregion

    #region ПАНЕЛЬ ВЫИГРЫША

    public void Finish() {
        GameEvents.onPaused?.Invoke(true);
        _finishPanel.SetActive(true);
        Dictionary<string, int> saveDictionary = new Dictionary<string, int>();

        var currentCoinInRound = GameEvents.onGetCoin?.Invoke();
        var coinText = $"Монеты в раунде:\n{currentCoinInRound}";
        _coinInRoundTextFromFinishPanel.text = coinText;

        int session = (int)GameEvents.onGetSession?.Invoke();
        
        int allCoinInSession = ReloadAllCoin(session, (int)currentCoinInRound);
        var allCoinText = $"Монеты за все пройденные лабиринты:\n{allCoinInSession}";
        _allCoinTextFromFinishPanel.text = allCoinText;
        // Debug.Log($"МОНЕТЫ ЗА ВСЕ РАУНДЫ В СЕССИИ = {allCoinInSession}");

        var passedRounds = ReloadPassedRounds(session);
        var passedRoundsText = $"Пройденные лабиринты:\n{passedRounds}";
        _passedRoundsTextFromFinishPanel.text = passedRoundsText;
        // Debug.Log($"ОБЩЕЕ КОЛЛИЧЕСТВО ПРОЙДЕННЫХ РАУНДОВ = {passedRounds}");

        saveDictionary.Add(GameConstants.All_COIN_IN_SESSION_KEY + session, allCoinInSession);
        saveDictionary.Add(GameConstants.PASSED_ROUNDS_KEY + session, passedRounds);
        SaveNewSizeMaze(saveDictionary);

        SavePlayerPrefsInt(saveDictionary);
    }

    private int ReloadPassedRounds(int session) {
        var finaleValue = 0;

        if(PlayerPrefs.HasKey(GameConstants.PASSED_ROUNDS_KEY + session)) {
            finaleValue = PlayerPrefs.GetInt(GameConstants.PASSED_ROUNDS_KEY + session);
        }
        finaleValue++;

        return finaleValue;
    }
    private int ReloadAllCoin(int session, int currentCoinInRound) {
        int allCoinInSession = 0;

        if(PlayerPrefs.HasKey(GameConstants.All_COIN_IN_SESSION_KEY + session)) {
            allCoinInSession = PlayerPrefs.GetInt(GameConstants.All_COIN_IN_SESSION_KEY + session);
        }

        var finishValue = allCoinInSession + currentCoinInRound;
        return finishValue;
    }
    private void SaveNewSizeMaze(Dictionary<string, int> saveDictionary) {
        var randomWidthMaze = 3;
        var randonHeightMaze = 3;

        if(PlayerPrefs.HasKey(GameConstants.MAZE_WIDTH_KEY)) {
            randomWidthMaze = PlayerPrefs.GetInt(GameConstants.MAZE_WIDTH_KEY);
        }

        if(PlayerPrefs.HasKey(GameConstants.MAZE_HEIGHT_KEY)) {
            randonHeightMaze = PlayerPrefs.GetInt(GameConstants.MAZE_HEIGHT_KEY);
        }

        var minWidthRandomValue = randomWidthMaze + 1;
        var maxWidthRandomValue = randomWidthMaze + 2;
        
        var mixHeightRandomValue = randonHeightMaze + 1;
        var maxHeightRandomValue = randonHeightMaze + 2;

        var widthRandNum = Random.Range(minWidthRandomValue, maxWidthRandomValue);
        var heightRandNum = Random.Range(mixHeightRandomValue, maxHeightRandomValue);

        saveDictionary.Add(GameConstants.MAZE_WIDTH_KEY, widthRandNum);
        saveDictionary.Add(GameConstants.MAZE_HEIGHT_KEY, heightRandNum);
    }

    #endregion

    private void SavePlayerPrefsInt(Dictionary<string, int> dictionary) {
        foreach(var VARIABLE in dictionary) {
            PlayerPrefs.SetInt(VARIABLE.Key, VARIABLE.Value);
            PlayerPrefs.Save();
        }
    }
}
