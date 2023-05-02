namespace Version_2 {
    public class MazeGeneratorCell {
        private int _x;
        private int _y;
        private int _distanceFromStart;

        private bool _wallLeft = true;
        private bool _wallBottom = true;
        private bool _visited;
        

        #region ГЕТТЕРЫ И СЕТТЕРЫ
        public int X { get => _x; set => this._x = value; }
        public int Y { get => _y; set => this._y = value; }
        
        public int DistanceFromStart { get => _distanceFromStart; set => this._distanceFromStart = value; }
        
        public bool WallLeft { get => _wallLeft; set => this._wallLeft = value; }
        public bool WallBottom { get => _wallBottom; set => this._wallBottom = value; }
        public bool Visited { get => _visited; set => this._visited = value; }

        #endregion
        
    }
}
