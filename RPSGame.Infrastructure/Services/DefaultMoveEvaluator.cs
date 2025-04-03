using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;
using RPSGame.Domain.Interfaces;
using RPSGame.Domain.Rules;

namespace RPSGame.Infrastructure.Services
{
    public class DefaultMoveEvaluator : IMoveEvaluator
    {
        private readonly MoveRules _moveRules;
        public DefaultMoveEvaluator()
        {
            _moveRules = new MoveRules();
        }
        public MoveResult Evaluate(Move playerMove, Move opponentMove)
        {
            if (_moveRules.Beats(playerMove.Name, opponentMove.Name))
                return MoveResult.Win;

            if (_moveRules.Beats(opponentMove.Name, playerMove.Name))
                return MoveResult.Lose;

            return MoveResult.Tie;
        }
    }
}
