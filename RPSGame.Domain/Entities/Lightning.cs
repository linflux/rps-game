namespace RPSGame.Domain.Entities
{
    public class Lightning : Move
    {
        public Lightning() : base("Lightning") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Water || otherMove is Sponge || otherMove is Devil;
        }
    }
}
