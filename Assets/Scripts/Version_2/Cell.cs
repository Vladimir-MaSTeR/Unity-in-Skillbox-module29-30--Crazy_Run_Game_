using UnityEngine;
using UnityEngine.Serialization;
public class Cell : MonoBehaviour {
    
    [SerializeField]
    [Tooltip("Левая стена из префаба")]
    private GameObject _wallLeft;

    [SerializeField]
    [Tooltip("Правая стена из префаба")]
    private GameObject _wallBottom;

    #region ГЕТТЕРЫ И СЕТТЕРЫ
    public GameObject WallLeft { get => _wallLeft; set => this._wallLeft = value; }
    public GameObject WallBottom { get => _wallBottom; set => this._wallBottom = value;
    }

    #endregion
}
