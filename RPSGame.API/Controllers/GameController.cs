using Microsoft.AspNetCore.Mvc;
using RPSGame.Application.Services;
using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;

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
            _gameService.SetPlayers(playerName);
            return Ok("Player name set successfully.");
        }

        [HttpGet("GetAvailableMoves")]
        public IActionResult GetAvailableMoves(GameLevel level)
        {
            var moves = _gameService.GetAvailableMoves(level);
            return Ok(moves);
        }

        [HttpGet("GetComputerMove")]
        public IActionResult GetComputerMove()
        {
            var move = _gameService.GetComputerMove();
            return Ok(move);
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