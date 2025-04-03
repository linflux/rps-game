namespace RPSGame.Domain.Entities
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Player name cannot be null or empty.");
            }
            Name = name;
            Score = 0;
        }

        public void IncrementScore()
        {
            Score++;
        }
    }
}
