using System.Collections.Generic;
using UnityEngine;
public class MazeGenerator_v2 {
    
    /**
     * Генерация лабиринта
     */
    public Maze GenerateMaze(int width, int height) {
        MazeGeneratorCell[,] cells = new MazeGeneratorCell[width, height];

        //Заполняем пустыми объектами
        for(int x = 0; x < cells.GetLength(0); x++) {
            for(int y = 0; y < cells.GetLength(1); y++) {
                cells[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        RandomActiveTrapsAndCoin(cells);

        for(int x = 0; x < cells.GetLength(0); x++) {
            cells[x, height - 1].WallLeft = false;
            cells[x, height - 1].Flor = false;
            cells[x, height - 1].Coin = false;
            cells[x, height - 1].LeftTrap = false;
            cells[x, height - 1].RightTrap = false;
        }

        for(int y = 0; y < cells.GetLength(1); y++) {
            cells[width - 1, y].WallBottom = false;
            cells[width - 1, y].Flor = false;
            cells[width - 1, y].Coin = false;
            cells[width - 1, y].LeftTrap = false;
            cells[width - 1, y].RightTrap = false;
        }

        RemoveWalls(cells, width, height);

        Maze maze = new Maze();
        maze.Cells = cells;
        maze.FinishPosition = PlaceMazeExit(cells, width, height);

        return maze;
    }

    private void RemoveWalls(MazeGeneratorCell[,] maze, int width, int height) {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do {
            //список не посещённых соседей
            List<MazeGeneratorCell> unVisited = new List<MazeGeneratorCell>();

            var x = current.X;
            var y = current.Y;

            if(x > 0 && !maze[x - 1, y].Visited) { unVisited.Add(maze[x - 1, y]); }
            if(y > 0 && !maze[x, y - 1].Visited) { unVisited.Add(maze[x, y - 1]); }

            if(x < width - 2 && !maze[x + 1, y].Visited) { unVisited.Add(maze[x + 1, y]); }
            if(y < height - 2 && !maze[x, y + 1].Visited) { unVisited.Add(maze[x, y + 1]); }

            //проверяем есть ли куда пойти, то-есть  есть ли хотя бы один сосед
            if(unVisited.Count > 0) {
                MazeGeneratorCell chosen = unVisited[Random.Range(0, unVisited.Count)];
                RemoveOneWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = current.DistanceFromStart + 1;
                current = chosen;
            } else {
                // Возвращаемся назад, достае из стека ячейку.
                current = stack.Pop();
            }
        } while(stack.Count > 0);
    }
    private void RemoveOneWall(MazeGeneratorCell current, MazeGeneratorCell chosen) {
        if(current.X == chosen.X) {
            if(current.Y > chosen.Y) {
                current.WallBottom = false;
            } else {
                chosen.WallBottom = false;
            }
        } else {
            if(current.X > chosen.X) {
                current.WallLeft = false;
            } else {
                chosen.WallLeft = false;
            }
        }
    }
    private Vector2Int PlaceMazeExit(MazeGeneratorCell[,] maze, int width, int height) {
        MazeGeneratorCell furthest = maze[0, 0];

        for(int x = 0; x < maze.GetLength(0); x++) {
            if(maze[x, height - 2].DistanceFromStart > furthest.DistanceFromStart) {
                furthest = maze[x, height - 2];
            }

            if(maze[x, 0].DistanceFromStart > furthest.DistanceFromStart) {
                furthest = maze[x, 0];
            }
        }

        for(int y = 0; y < maze.GetLength(1); y++) {
            if(maze[width - 2, y].DistanceFromStart > furthest.DistanceFromStart) {
                furthest = maze[width - 2, y];
            }

            if(maze[0, y].DistanceFromStart > furthest.DistanceFromStart) {
                furthest = maze[0, y];
            }
        }

        // ломаем стену вне лабиринта но проще в furthest поставить объект финиша
        // if(furthest.X == 0) {
        //     furthest.WallLeft = false;
        // } else if(furthest.Y == 0) {
        //     furthest.WallBottom = false;
        // } else if(furthest.X == width - 2) {
        //     maze[furthest.X + 1, furthest.Y].WallLeft = false;
        // } else if(furthest.Y == height - 2) {
        //     maze[furthest.X, furthest.Y + 1].WallBottom = false;
        // }

        furthest.Coin = false;
        furthest.LeftTrap = false;
        furthest.RightTrap = false;
        furthest.FinishObject = true;

        return new Vector2Int(furthest.X, furthest.Y);
    }
    private void RandomActiveTrapsAndCoin(MazeGeneratorCell[,] maze) {
        for(int x = 0; x < maze.GetLength(0); x++) {
            for(int y = 0; y < maze.GetLength(1); y++) {
                var randomNumber = Random.Range(0, 20);

                if(randomNumber == 0 || randomNumber == 1 || randomNumber == 2 || 
                   randomNumber == 3 || randomNumber == 4 || randomNumber == 5 ||
                   randomNumber == 6 || randomNumber == 7 || randomNumber == 8 || randomNumber == 9) {
                    maze[x, y].Coin = true;
                }

                if(randomNumber == 10 || randomNumber == 11 || randomNumber == 12) {
                    maze[x, y].LeftTrap = true;
                }

                if(randomNumber == 19 || randomNumber == 18 || randomNumber == 19) {
                    maze[x, y].RightTrap = true;
                }
            }
        }

        maze[0, 0].Coin = false;
        maze[0, 0].RightTrap = false;
        maze[0, 0].LeftTrap = false;
    }
}
