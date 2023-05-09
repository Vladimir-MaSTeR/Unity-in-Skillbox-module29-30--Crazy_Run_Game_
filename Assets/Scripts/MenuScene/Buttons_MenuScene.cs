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
    
    

    public void ClickAutorPanelAndBack() {
        if(_mainPanel.activeSelf || _autorPanel.activeSelf) {
            _mainPanel.SetActive(!_mainPanel.activeSelf);
            _autorPanel.SetActive(!_autorPanel.activeSelf);
        }
    }

    public void ClickSettinsPanelAndBack() {
        if(_mainPanel.activeSelf || _settingsPanel.activeSelf) {
            _mainPanel.SetActive(!_mainPanel.activeSelf);
            _settingsPanel.SetActive(!_settingsPanel.activeSelf);

            //Ещё нужно сохранять настройки и загружать для отображения их на ползунках звука соответственно
        }
    }

    public void CkickStartGame() {

        var sessionNumber = 0;
        //получаем сессию
        if(PlayerPrefs.HasKey(GameConstants.SESSION_KEY)) {
            sessionNumber = PlayerPrefs.GetInt(GameConstants.SESSION_KEY);
            sessionNumber++;
        }
        
        PlayerPrefs.SetInt(GameConstants.SESSION_KEY, sessionNumber);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene(GameConstants.GAME_SCENE_INDEX);
    }

    public void ClickExitGame() {
        Application.Quit();
    }
}
