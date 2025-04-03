namespace RPSGame.Domain.Entities;

public class Dragon : Move
{
    public Dragon() : base("Dragon") { }
    public override bool Beats(Move otherMove)
    {
        return otherMove is Wolf || otherMove is Tree;
    }
}
