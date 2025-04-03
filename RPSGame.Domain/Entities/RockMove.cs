namespace RPSGame.Domain.Entities;

public class Rock : Move
{
    public Rock() : base("Rock") { }
    public override bool Beats(Move otherMove) => otherMove is Scissors;
}