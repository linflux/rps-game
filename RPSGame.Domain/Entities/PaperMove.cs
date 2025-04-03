namespace RPSGame.Domain.Entities;

public class Paper : Move
{
    public Paper() : base("Paper") { }
    public override bool Beats(Move otherMove) => otherMove is Rock;
}