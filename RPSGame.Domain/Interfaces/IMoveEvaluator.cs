using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;

namespace RPSGame.Domain.Interfaces
{
    public interface IMoveEvaluator
    {
        MoveResult Evaluate(Move move1, Move move2);
    }
}
