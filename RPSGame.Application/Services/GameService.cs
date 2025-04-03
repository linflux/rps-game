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

        public Player Player { get; private set; }
        public Player Computer { get; private set; }

        public GameService(IMoveEvaluator moveEvaluator)
        {
            _moveEvaluator = moveEvaluator;
            _availableMoves = new List<Move>();
            Player = new Player("Player");
            Computer = new Player("Computer");
        }

        public void SetGameLevel(GameLevel level)
        {
            _availableMoves = MoveFactory.GetMoves(level);
        }

        public List<Move> GetAvailableMoves()
        {
            return _availableMoves; // _availableMoves is the private field storing available moves for the current game level.
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

        public void SetPlayers(string playerName)
        {
            Player = new Player(playerName);
            Computer = new Player("Computer");
        }

        public int GetPlayerScore() => Player.Score.Value;

        public int GetComputerScore() => Computer.Score.Value;

        public Move GetComputerMove()
        {
            return _availableMoves[_random.Next(_availableMoves.Count)];
        }

        public string GetScore()
        {
            return $"{Player.Name}: {Player.Score.Value} - {Computer.Name}: {Computer.Score.Value}";
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
                PlayerScore = Player.Score.Value,
                ComputerScore = Computer.Score.Value
            };
        }
    }
}
