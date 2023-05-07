using UnityEngine;
public class Maze {
    private MazeGeneratorCell[,] _cells;
    private Vector2Int _finishPosition;

    #region ГЕТТЕРЫ И СЕТТЕРЫ
    public MazeGeneratorCell[,] Cells {get => _cells; set => this._cells = value;}
    public Vector2Int FinishPosition {get => _finishPosition; set => this._finishPosition = value;}
    #endregion
}
