namespace RPSGame.Domain.Entities
{
    public class Fire : Move
    {
        public Fire() : base("Fire") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Rock || otherMove is Sponge || otherMove is Devil;
        }
    }
}
