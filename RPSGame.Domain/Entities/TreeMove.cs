namespace RPSGame.Domain.Entities;

public class Tree : Move
{
    public Tree() : base("Tree") { }
    public override bool Beats(Move otherMove)
    {
        return otherMove is Paper || otherMove is Human;
    }
}
