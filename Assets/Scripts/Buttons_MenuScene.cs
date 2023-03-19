using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_MenuScene : MonoBehaviour
{
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
        SceneManager.LoadScene(1);

    }

    public void ClickExitGame() {
        Application.Quit();
    }


}
