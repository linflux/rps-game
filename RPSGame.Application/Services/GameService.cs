using RPSGame.Domain.Entities;
using RPSGame.Domain.Interfaces;
using RPSGame.Application.Factories;
using RPSGame.Application.Rules;

namespace RPSGame.Application.Services
{
    public class GameService
    {
        private readonly IMoveEvaluator _moveEvaluator;
        private List<Move> _availableMoves;

        public Player Player { get; private set; }
        public Player Computer { get; private set; }

        public GameService(IMoveEvaluator moveEvaluator)
        {
            _moveEvaluator = moveEvaluator;
            _availableMoves = new List<Move>();
        }


        public void SetGameLevel(GameLevel level)
        {
            _availableMoves = MoveFactory.GetMoves(level);
        }

        public List<Move> GetAvailableMoves()
        {
            return _availableMoves; // _availableMoves is the private field storing available moves for the current game level.
        }

        public void SetPlayers(string playerName)
        {
            Player = new Player(playerName);
            Computer = new Player("Computer");
        }

        public int GetPlayerScore() => Player.Score;

        public int GetComputerScore() => Computer.Score;
        

        public string Play(string playerMoveName, string opponentMoveName)
        {
            var playerMove = _availableMoves.FirstOrDefault(m => m.Name == playerMoveName);
            var opponentMove = _availableMoves.FirstOrDefault(m => m.Name == opponentMoveName);

            if (playerMove == null || opponentMove == null)
                throw new ArgumentException("Invalid move");

            if (playerMove.Beats(opponentMove))
            {
                Player.IncrementScore();
                return $"{playerMove.Name} beats {opponentMove.Name}!";
            }
            
            if (opponentMove.Beats(playerMove))
            {
                Computer.IncrementScore();
                return $"{opponentMove.Name} beats {playerMove.Name}!";
            }

            return "It's a tie!";
        }
    }
}
