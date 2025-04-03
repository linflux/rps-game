namespace RPSGame.Domain.Entities;

public class Spock : Move
{
    public Spock() : base("Spock") { }

    public override bool Beats(Move otherMove)
    {
        return otherMove is Scissors || otherMove is Rock;
    }
}
