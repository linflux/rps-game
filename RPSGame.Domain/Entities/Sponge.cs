namespace RPSGame.Domain.Entities
{
    public class Sponge : Move
    {
        public Sponge() : base("Sponge") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Water || otherMove is Gun || otherMove is Rock;
        }
    }
}
