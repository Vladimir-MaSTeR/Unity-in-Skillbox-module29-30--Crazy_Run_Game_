using UnityEngine;
using UnityEngine.Serialization;
public class Cell : MonoBehaviour {
    
    [SerializeField]
    [Tooltip("Левая стена из префаба")]
    private GameObject _wallLeft;

    [SerializeField]
    [Tooltip("Правая стена из префаба")]
    private GameObject _wallBottom;
    
    [SerializeField]
    [Tooltip("Пол")]
    private GameObject _flor;
    
    [SerializeField]
    [Tooltip("Пол")]
    private GameObject _finishObject;

    #region ГЕТТЕРЫ И СЕТТЕРЫ
    public GameObject WallLeft { get => _wallLeft; set => this._wallLeft = value; }
    public GameObject WallBottom {get => _wallBottom; set => this._wallBottom = value;}
    public GameObject Flor {get => _flor; set => this._flor = value;}
    public GameObject FinishObject {get => _finishObject; set => this._finishObject = value;}

    #endregion
}
