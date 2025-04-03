namespace RPSGame.Domain.Entities;

public class Wolf : Move
{
    public Wolf() : base("Wolf") { }
    public override bool Beats(Move otherMove)
    {
        return otherMove is Human || otherMove is Tree;
    }
}
