using Microsoft.AspNetCore.Mvc;
using RPSGame.Application.Services;
using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;
using RPSGame.Application.Entities;

namespace RPSGame.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("SetGameLevel")]
        public IActionResult SetGameLevel([FromBody] GameLevel level)
        {
            _gameService.SetGameLevel(level);
            return Ok("Game level set successfully.");
        }

        [HttpPost("SetPlayerName")]
        public IActionResult SetPlayerName([FromBody] string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                return BadRequest("Player name cannot be empty.");
            }
            _gameService.SetPlayer(playerName);
            Console.WriteLine($"Player name set to: {playerName}");
            return Ok("Player name set successfully.");
        }

        [HttpGet("GetPlayerName")]
        public IActionResult GetPlayerName()
        {
            var playerName = _gameService.GetPlayerName();
            Console.WriteLine($"Player name retrieved: {playerName}");
            return Ok(playerName);
        }

        [HttpGet("GetAvailableMoves")]
        public IActionResult GetAvailableMoves(GameLevel level)
        {
            var moves = _gameService.GetAvailableMoves(level)
                        .Select(m => new ConcreteMove(m.Name))
                        .ToList();
            return Ok(moves);
        }

        [HttpGet("GetMove")]
        public IActionResult GetMove(string moveName)
        {
            var move = _gameService.GetMove(moveName);

            if (move == null)
            {
                return NotFound($"Move '{moveName}' not found.");
            }

            return Ok(new ConcreteMove(move.Name));
        }

        [HttpGet("GetComputerMove")]
        public IActionResult GetComputerMove()
        {
            var move = _gameService.GetComputerMove();

            return Ok(new ConcreteMove(move.Name));
        }

        [HttpPost("Play")]
        public IActionResult Play([FromBody] PlayRequest request)
        {
            var result = _gameService.Play(request.PlayerMove, request.ComputerMove);
            return Ok(result);
        }
    }

    public class PlayRequest
    {
        public string PlayerMove { get; set; }
        public string ComputerMove { get; set; }
    }
}