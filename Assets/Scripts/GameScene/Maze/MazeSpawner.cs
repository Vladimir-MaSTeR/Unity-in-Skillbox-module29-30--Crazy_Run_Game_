using System;
using UnityEngine;
public class MazeSpawner : MonoBehaviour {
    #region ПЕРЕМЕННЫЕ ДВИЖКА

    [Header("Параметры")]
    [SerializeField]
    [Tooltip("Ширина лабиринта")]
    private int _width = 10;

    [SerializeField]
    [Tooltip("Высота лабиринта")]
    private int _height = 9;

    [SerializeField]
    [Tooltip("Префаб стены")]
    private GameObject _cellPrefab;

    [SerializeField]
    [Tooltip("Размер ячейки")]
    private Vector3 _cellSize = new Vector3(1, 1, 0);

    [Space(20)]
    [SerializeField]
    private HintRenderer _hintRendererScript;

    #endregion

    private Maze _maze;

    private void Awake() { ReloadSizeMaze(); }
    private void Start() {
        MazeGenerator_v2 generatorV2 = new MazeGenerator_v2();
        _maze = generatorV2.GenerateMaze(_width, _height);

        for(int x = 0; x < _maze.Cells.GetLength(0); x++) {
            for(int y = 0; y < _maze.Cells.GetLength(1); y++) {
                Cell cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity).GetComponent<Cell>();

                cell.WallLeft.SetActive(_maze.Cells[x, y].WallLeft);
                cell.WallBottom.SetActive(_maze.Cells[x, y].WallBottom);
                cell.Flor.SetActive(_maze.Cells[x, y].Flor);
                cell.CoinObject.SetActive(_maze.Cells[x, y].Coin);
                cell.LeftTrapObject.SetActive(_maze.Cells[x, y].LeftTrap);
                cell.RightTrapObject.SetActive(_maze.Cells[x, y].RightTrap);
                cell.FinishObject.SetActive(_maze.Cells[x, y].FinishObject);
            }
        }

       
        _hintRendererScript.DrawPath();
    }

    private void ReloadSizeMaze() {
        if(PlayerPrefs.HasKey(GameConstants.MAZE_WIDTH_KEY)) {
            _width = PlayerPrefs.GetInt(GameConstants.MAZE_WIDTH_KEY);
        }

        if(PlayerPrefs.HasKey(GameConstants.MAZE_HEIGHT_KEY)) {
            _height = PlayerPrefs.GetInt(GameConstants.MAZE_HEIGHT_KEY);
        }
    }

    #region ГЕТТЕРЫ И СЕТТЕРЫ

    public int Width { get => _width; set => this._width = value; }
    public int Height { get => _height; set => this._height = value; }
    public Vector3 CellSize { get => _cellSize; set => this._cellSize = value; }
    public Maze Maze { get => _maze; set => this._maze = value; }

    #endregion
}
