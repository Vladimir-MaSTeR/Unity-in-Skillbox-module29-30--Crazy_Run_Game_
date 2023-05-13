using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons_MenuScene : MonoBehaviour {
    [Header("ПАНЕЛИ")]
    [Tooltip("Главная панель")]
    [SerializeField]
    private GameObject _mainPanel;

    [Tooltip("Панельс с указанием автора")]
    [SerializeField]
    private GameObject _autorPanel;

    [Tooltip("Панель настроек")]
    [SerializeField]
    private GameObject _settingsPanel;
    
    [Tooltip("Панель настроек")]
    [SerializeField]
    private GameObject _statisticsPanel;
    
    

    public void ClickAutorPanelAndBack() {
        if(_mainPanel.activeSelf || _autorPanel.activeSelf) {
            _mainPanel.SetActive(!_mainPanel.activeSelf);
            _autorPanel.SetActive(!_autorPanel.activeSelf);
            _statisticsPanel.SetActive(!_statisticsPanel.activeSelf);
        }
    }

    public void ClickSettinsPanelAndBack() {
        if(_mainPanel.activeSelf || _settingsPanel.activeSelf) {
            _mainPanel.SetActive(!_mainPanel.activeSelf);
            _settingsPanel.SetActive(!_settingsPanel.activeSelf);
            _statisticsPanel.SetActive(!_statisticsPanel.activeSelf);

            //Ещё нужно сохранять настройки и загружать для отображения их на ползунках звука соответственно
        }
    }

    public void CkickStartGame() {

        var sessionNumber = 0;
        //получаем сессию
        if(PlayerPrefs.HasKey(GameConstants.SESSION_KEY)) {
            sessionNumber = PlayerPrefs.GetInt(GameConstants.SESSION_KEY);
            Debug.Log($"Загрузил номер прошлой сессии = {sessionNumber}");
        }
        
        sessionNumber++;

        PlayerPrefs.SetInt(GameConstants.SESSION_KEY, sessionNumber);
        PlayerPrefs.Save();
        Debug.Log($" Сохранил номер сессии = {sessionNumber}");
        
        PlayerPrefs.SetInt(GameConstants.MAZE_WIDTH_KEY, 3);
        PlayerPrefs.SetInt(GameConstants.MAZE_HEIGHT_KEY, 3);
        PlayerPrefs.SetInt(GameConstants.PASSED_ROUNDS_KEY + sessionNumber, 0);
        
        SceneManager.LoadScene(GameConstants.GAME_SCENE_INDEX);
    }

    public void ClickRemoveStatsSaves() {
        PlayerPrefs.DeleteAll();
        GameEvents.onRemoveStatsSaves?.Invoke();
    }

    public void ClickExitGame() {
        Application.Quit();
    }
}
