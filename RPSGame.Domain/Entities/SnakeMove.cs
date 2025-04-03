namespace RPSGame.Domain.Entities;

public class Snake : Move
{
    public Snake() : base("Snake") { }
    public override bool Beats(Move otherMove)
    {
        return otherMove is Dragon || otherMove is Wolf;
    }
}
