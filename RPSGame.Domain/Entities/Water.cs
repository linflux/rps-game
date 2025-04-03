namespace RPSGame.Domain.Entities
{
    public class Water : Move
    {
        public Water() : base("Water") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Fire || otherMove is Sponge || otherMove is Gun;
        }
    }
}
