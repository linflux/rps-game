namespace RPSGame.Domain.Entities
{
    public abstract class Move
    {
        public string Name { get; }
        protected Move(string name) => Name = name;

        public abstract bool Beats(Move otherMove);
    }
}
