namespace RPSGame.Domain.Entities;


public class Scissors : Move
{
    public Scissors() : base("Scissors") { }
    public override bool Beats(Move otherMove) => otherMove is Paper;
}