using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;
using RPSGame.Domain.Interfaces;
using RPSGame.Application.Factories;
using RPSGame.Domain.Rules;

namespace RPSGame.Application.Services
{
    public class GameService : IGameService
    {
        private static readonly Random _random = new Random();

        private readonly IMoveEvaluator _moveEvaluator;
        private List<Move> _availableMoves;

        public Player Player { get; set; }
        public Player Computer { get; set; }

        public GameService(IMoveEvaluator moveEvaluator)
        {
            _moveEvaluator = moveEvaluator;
            _availableMoves = MoveFactory.GetMoves(GameLevel.Easy);
            Player = new Player("Player");
            Computer = new Player("Computer");
        }

        public void SetGameLevel(GameLevel level)
        {
            _availableMoves = MoveFactory.GetMoves(level);
        }

        public List<Move> GetAvailableMoves(GameLevel level)
        {
            _availableMoves = MoveFactory.GetMoves(level);
            return _availableMoves;
        }

        public Move GetMove(string moveName)
        {
            if (string.IsNullOrWhiteSpace(moveName))
                throw new ArgumentException("Move name cannot be null or empty.");

            var move = _availableMoves.FirstOrDefault(m => m.Name.Equals(moveName, StringComparison.OrdinalIgnoreCase));

            if (move == null)
                throw new ArgumentException($"Move '{moveName}' is not available.");

            return move;
        }

        public void SetPlayer(string playerName)
        {
            if (Player == null)
            {
                Player = new Player(playerName); // Initialize Player if it doesn't exist
            }
            else
            {
                Player.Name = playerName; // Update the name without replacing the object
            }

            if (Computer == null)
            {
                Computer = new Player("Computer"); // Initialize Computer if it doesn't exist
            }
        }

        public string GetPlayerName() => Player?.Name ?? "Player";

        public int GetPlayerScore() => Player.Score.Value;

        public int GetComputerScore() => Computer.Score.Value;

        public Move GetComputerMove()
        {
            return _availableMoves[_random.Next(_availableMoves.Count)];
        }

        private string GetScore()
        {
            return $"{Player?.Name}: {Player?.Score?.Value} - {Computer.Name}: {Computer.Score.Value}";
        }

        public GamePlayResult Play(string playerMoveName, string opponentMoveName)
        {
            var playerMove = _availableMoves.FirstOrDefault(m => m.Name == playerMoveName);
            var opponentMove = _availableMoves.FirstOrDefault(m => m.Name == opponentMoveName);

            if (playerMove == null || opponentMove == null)
                throw new ArgumentException("Invalid move");

            var moveResult = _moveEvaluator.Evaluate(playerMove, opponentMove);

            string message = moveResult switch
            {
                MoveResult.Win => $"{playerMove.Name} beats {opponentMove.Name}!",
                MoveResult.Lose => $"{opponentMove.Name} beats {playerMove.Name}!",
                MoveResult.Tie => "It's a tie!",
                _ => throw new InvalidOperationException("Unexpected result from move evaluation.")
            };

            if (moveResult == MoveResult.Win)
                Player.IncrementScore();
            else if (moveResult == MoveResult.Lose)
                Computer.IncrementScore();

            return new GamePlayResult
            {
                Message = message,
                ScoreMessage = this.GetScore(),
                MoveResult = moveResult,
                PlayerScore = Player?.Score?.Value,
                ComputerScore = Computer.Score.Value
            };
        }
    }
}
