using RPSGame.Domain.Entities;

namespace RPSGame.Domain.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Score Score { get; }
        void IncrementScore();
    }
}