using Microsoft.AspNetCore.Mvc;

namespace Herxagon.GameOfLife.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{

    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGame")]
    public ActionResult<Grid> Get()
    {
        var grid = new Grid
        {
            Length = 12,
            Width = 12
        };

        return grid;
    }
    
    [HttpPost(Name = "NewGame")]
    public ActionResult<Game> Post([FromBody] GameInitRequest body)
    {

        var game = new Game
        {
            Grid = new Grid
            {
                Length = body.GridX,
                Width = body.GridY
            }
        };
        
        return game;
    }
    
    [HttpPost("start", Name = "StartGame")]
    public ActionResult<GameStartResponse> Post([FromBody] GameStartRequest body)
    {

        var game = new GameStartResponse()
        {
            Message = "Game Started"
            
        };
        
        return game;
    }
}
