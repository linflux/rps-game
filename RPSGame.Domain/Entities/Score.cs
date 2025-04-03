namespace RPSGame.Domain.Entities
{
    public class Score
    {
        public int Value { get; private set; }

        public Score()
        {
            Value = 0;
        }

        public void Increment()
        {
            Value++;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}