namespace RPSGame.Domain.Entities
{
    public class Air : Move
    {
        public Air() : base("Air") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Fire || otherMove is Sponge || otherMove is Lightning;
        }
    }
}
