using RPSGame.Domain.Entities;

namespace RPSGame.Domain.Interfaces
{
    public interface IMoveEvaluator
    {
        bool Evaluate(Move move1, Move move2);
    }
}
