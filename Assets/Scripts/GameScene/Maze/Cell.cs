﻿using UnityEngine;
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
    [Tooltip("Финишь")]
    private GameObject _finishObject;

    [SerializeField]
    [Tooltip("Монетка")]
    private GameObject _coinObject;

    [SerializeField]
    [Tooltip("Левая ловушка")]
    private GameObject _leftTrapObject;

    [SerializeField]
    [Tooltip("Правая ловушка")]
    private GameObject _rightTrapObject;

    #region ГЕТТЕРЫ И СЕТТЕРЫ

    public GameObject WallLeft { get => _wallLeft; set => this._wallLeft = value; }
    public GameObject WallBottom { get => _wallBottom; set => this._wallBottom = value; }
    public GameObject Flor { get => _flor; set => this._flor = value; }
    public GameObject FinishObject { get => _finishObject; set => this._finishObject = value; }
    public GameObject CoinObject { get => _coinObject; set => this._coinObject = value; }
    public GameObject LeftTrapObject { get => _leftTrapObject; set => this._leftTrapObject = value; }
    public GameObject RightTrapObject { get => _rightTrapObject; set => this._rightTrapObject = value; }

    #endregion
}
