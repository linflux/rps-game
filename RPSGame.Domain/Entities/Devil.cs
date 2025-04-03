namespace RPSGame.Domain.Entities
{
    public class Devil : Move
    {
        public Devil() : base("Devil") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Sponge || otherMove is Fire || otherMove is Air;
        }
    }
}
