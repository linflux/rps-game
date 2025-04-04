namespace RPSGame.Domain.Entities
{
    public abstract class Move
    {
        public string Name { get; set; }
        protected Move(string name) => Name = name;

        public abstract bool Beats(Move otherMove);

        public override string ToString()
        {
            return Name;
        }
    }
}
