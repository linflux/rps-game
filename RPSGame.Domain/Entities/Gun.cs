namespace RPSGame.Domain.Entities
{
    public class Gun : Move
    {
        public Gun() : base("Gun") { }

        public override bool Beats(Move otherMove)
        {
            return otherMove is Rock || otherMove is Devil || otherMove is Air;
        }
    }
}
