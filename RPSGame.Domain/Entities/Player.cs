using RPSGame.Domain.Interfaces;

namespace RPSGame.Domain.Entities
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public Score Score { get; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Player name cannot be null or empty.");
            }
            Name = name;
            Score = new Score();
        }

        public void IncrementScore()
        {
            Score.Increment();
        }

        public override string ToString()
        {
            return $"{Name} (Score: {Score})";
        }
    }
}
