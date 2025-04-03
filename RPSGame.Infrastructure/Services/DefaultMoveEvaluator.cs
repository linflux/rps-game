using RPSGame.Domain.Entities;
using RPSGame.Domain.Interfaces;

namespace RPSGame.Infrastructure.Services
{
    public class DefaultMoveEvaluator : IMoveEvaluator
    {
        public bool Evaluate(Move move1, Move move2)
        {
            return move1.Beats(move2);
        }
    }
}
