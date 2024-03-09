using System.Text.Json;

namespace Herxagon.GameOfLife.Api;

public class Game
{
    public Grid Grid = new Grid
    {
        Length = 0,
        Width = 0
    };

    public bool[,] GameState = new bool[0, 0];
}

public class GOL
{
    public bool[,] grid;

    public void Init(int rows, int cols)
    {
        grid = new bool[rows, cols];
    }
    

    public void SetInitialCellState(int [,] activeCells)
    {
        for (int i = 0; i < activeCells.GetLength(0); i++)
        {
            int row = activeCells[i, 0];
            int col = activeCells[i, 1];
        
            grid[row, col] = true;
        }
    }
    public void SetCellState(int row, int col, bool state)
    {
        grid[row, col] = state;
    }

    public bool GetCellState(int row, int col)
    {
        return grid[row, col];
    }

    public void SetCellState(int row, int col)
    {
        grid[row, col] = !grid[row, col];
    }

    public void TraverseGrid()
    // Any live cell with fewer than two live neighbors dies (underpopulation).
    // Any live cell with two or three live neighbors lives on to the next generation.
    // Any live cell with more than three live neighbors dies (overpopulation).
    // Any dead cell with exactly three live neighbors becomes a live cell (reproduction).
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                bool cell = grid[i, j];
                
                // dead cell
                if (!cell)
                {
                    // checking row above
                    if (grid[i+1, j])
                    {
                        
                    }
                    // checking row below
                    if (grid[i-1, j])
                    {
                        
                    }
                    // checking next column
                    if (grid[i, j+1])
                    {
                        
                    }
                    // checking previous column
                    if (grid[i, j-1])
                    {
                        
                    }
                }
                
            }
        }
    }
    
    
    public bool[,] NextGeneration(bool[,] currentGeneration)
    {
        int rows = currentGeneration.GetLength(0);
        int cols = currentGeneration.GetLength(1);
        bool[,] newGeneration = new bool[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int liveNeighbors = CountLiveNeighbors(currentGeneration, row, col);
                bool isAlive = currentGeneration[row, col];

                if (isAlive)
                {
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                        newGeneration[row, col] = false; // Cell dies due to underpopulation or overpopulation
                    else
                        newGeneration[row, col] = true; // Cell survives to next generation
                }
                else
                {
                    if (liveNeighbors == 3)
                        newGeneration[row, col] = true; // Cell becomes alive due to reproduction
                    else
                        newGeneration[row, col] = false; // Cell remains dead
                }
            }
        }

        return newGeneration;
    }

    private int CountLiveNeighbors(bool[,] grid, int row, int col)
    {
        int liveNeighbors = 0;
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue; // Skip the cell itself
                int r = row + i;
                int c = col + j;
                if (r >= 0 && r < rows && c >= 0 && c < cols && grid[r, c])
                    liveNeighbors++;
            }
        }

        return liveNeighbors;
    }

    public string Serialize2DArrJson(bool[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        // Convert the 2D array into a jagged array
        bool[][] jaggedArray = new bool[rows][];
        for (int i = 0; i < rows; i++)
        {
            jaggedArray[i] = new bool[cols];
            for (int j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = arr[i, j];
            }
        }
        
        return JsonSerializer.Serialize(jaggedArray);
    }
    
    public int[,] DeSerialize2DArrJson(string json)
    {
        int[][] jaggedArray = JsonSerializer.Deserialize<int[][]>(json);

        int rows = jaggedArray.Length;
        int cols = jaggedArray[0].Length;

        int[,] array = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = jaggedArray[i][j];
            }
        }

        return array;
    }
    
}

public class GameInitRequest
{
    public int GridX { get; set; }
    public int GridY { get; set; }
}
public class GameStartRequest
{
    public int GridX { get; set; }
    public int GridY { get; set; }
    public string AliveCells { get; set; }
}
public class GameStartResponse
{
    public string Message { get; set; }
    public string Game { get; set; }
}

public class Grid
{
    public int Length { get; set; }
    public int Width { get; set; }
    public string[] ActiveCells {get; set; }
}
