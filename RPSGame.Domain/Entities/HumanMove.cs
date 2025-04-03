namespace RPSGame.Domain.Entities;

public class Human : Move
{
    public Human() : base("Human") { }
    public override bool Beats(Move otherMove)
    {
        return otherMove is Snake || otherMove is Scissors;
    }
}
