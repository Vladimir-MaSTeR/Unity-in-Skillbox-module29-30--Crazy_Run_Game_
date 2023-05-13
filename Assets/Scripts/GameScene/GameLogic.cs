using TMPro;
using UnityEngine;
public class GameLogic : MonoBehaviour {
    
    #region ПЕРЕМЕННЫЕ ДВИЖКА

    [SerializeField]
    [Tooltip("Стартовое колличесво монет")]
    private int _startCoin;

    [SerializeField]
    [Tooltip("Время раунда в секундах")]
    private float _startRoundTime = 10f;

    [Space(20)]
    [Header("Текстовые поля")]
    [SerializeField]
    private TMP_Text _coinText;

    [SerializeField]
    private TMP_Text _roundTimeText;

    #endregion

    private int _currentCoin;
    private float _currentRoundTime;
    private bool _paused = false;

    /**
     * Задумка следующая - при нажатии кнопки старт в меню игры
     * эта переменная всегда только увеличивается.
     * Переменна уникальна.
     * Показывает текущую сессию к которой нужно привязать сохранение статистики.
     */
    private int _sessionNumber = 0;

    private void Awake() {
        _currentCoin = _startCoin;
        _currentRoundTime = _startRoundTime;

        UpdateCoinText(_currentCoin);
        _paused = false;
        
        //получаем сессию
        if(PlayerPrefs.HasKey(GameConstants.SESSION_KEY)) {
            _sessionNumber = PlayerPrefs.GetInt(GameConstants.SESSION_KEY);
            Debug.Log($"Загрузил номер сессии = {_sessionNumber}");
        }
    }

    private void OnEnable() {
        GameEvents.onPaused += SetPausedEvent;
        GameEvents.onGetCoin += GetCurrentCoinEvent;
        GameEvents.onAddCoin += AddOneCoin;
        GameEvents.onModifayCoin += ModifayCoin;
        GameEvents.onGetSession += GetSessionNumberEvent;
    }
    private void OnDisable() {
        GameEvents.onPaused -= SetPausedEvent;
        GameEvents.onGetCoin -= GetCurrentCoinEvent;
        GameEvents.onAddCoin -= AddOneCoin;
        GameEvents.onModifayCoin -= ModifayCoin;
        GameEvents.onGetSession -= GetSessionNumberEvent;
    }

    private void FixedUpdate() {
        ManagementRoundTime();
    }

    private void ManagementRoundTime() {
        if(!_paused) {
            if(_currentRoundTime > 0) {
                UpdateTimerText(_currentRoundTime);
                //UpdateCoinText(_currentCoin);

                _currentRoundTime -= Time.deltaTime;
            } else {
                // Debug.Log("ВЫ ПРОИГРАЛИ");
                GameEvents.onGameOver?.Invoke();
            }
        }
    }

    private void AddOneCoin() {
        _currentCoin++;
        UpdateCoinText(_currentCoin);
    }
    
    private void ModifayCoin(bool plusOrMinus, int value) {

        if(plusOrMinus) {
            _currentCoin += value;
        } else {
            _currentCoin -= value;
        }

        if(_currentCoin < 0) {
            _currentCoin = 0;
        }
        
        UpdateCoinText(_currentCoin);
    }

    private void UpdateTimerText(float time) {
        if(time < 0) { time = 0; }

        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time % 60);
        _roundTimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void UpdateCoinText(int value) {
        var finaleText = $"Монеты: {value}";
        _coinText.text = finaleText;
    }

    #region ГЕТТЕРЫ И СЕТТЕРЫ

    private void SetPausedEvent(bool value) { _paused = value; }
    private int GetCurrentCoinEvent() { return _currentCoin; }

    public int CurrentCoin { get => _currentCoin; set => _currentCoin = value; }

    public float CurrentRoundTime { get => _currentRoundTime; set => _currentRoundTime = value; }
    
    private int GetSessionNumberEvent() {
        return _sessionNumber;
    }

    #endregion
}
