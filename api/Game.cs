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

public class GameInitRequest
{
    public int GridX { get; set; }
    public int GridY { get; set; }
}
public class GameStartRequest
{
    public int GridX { get; set; }
    public int GridY { get; set; }
}
public class GameStartResponse
{
    public string Message { get; set; }
}

public class Grid
{
    public int Length { get; set; }
    public int Width { get; set; }
    public string[] ActiveCells {get; set; }
}
