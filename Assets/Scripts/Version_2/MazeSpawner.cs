using UnityEngine;
public class MazeSpawner : MonoBehaviour {
    
    #region ���������� ������

    [Header("���������")]
    [SerializeField]
    [Tooltip("������ ���������")]
    private int _width = 10;

    [SerializeField]
    [Tooltip("������ ���������")]
    private int _height = 9;

    [SerializeField]
    [Tooltip("������ �����")]
    private GameObject _cellPrefab;

    [SerializeField]
    [Tooltip("������ ������")]
    private Vector3 _cellSize = new Vector3(1, 1, 0);

    [Space(20)]
    
    [SerializeField]
    private HintRenderer _hintRendererScript;

    
    
    #endregion

    private Maze _maze;
    private void Start() {
        MazeGenerator_v2 generatorV2 = new MazeGenerator_v2();
        _maze = generatorV2.GenerateMaze(_width, _height);

        for(int x = 0; x  < _maze.Cells.GetLength(0); x++) {
            for(int y = 0; y < _maze.Cells.GetLength(1); y++) {
                Cell cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity).GetComponent<Cell>();

                cell.WallLeft.SetActive(_maze.Cells[x, y].WallLeft);
                cell.WallBottom.SetActive(_maze.Cells[x, y].WallBottom);
            }
        }
        
        _hintRendererScript.DrawPath();
    }

    #region ������� � �������

    public int Width {get => _width; set => this._width = value;}
    public int Height {get => _height; set => this._height = value;}
    public Vector3 CellSize {get => _cellSize; set => this._cellSize = value;}
    public Maze Maze {get => _maze; set => this._maze = value;}

    #endregion

   
}
