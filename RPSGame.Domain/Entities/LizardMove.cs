namespace RPSGame.Domain.Entities;

public class Lizard : Move
{
    public Lizard() : base("Lizard") { }
    public override bool Beats(Move otherMove) => otherMove is Paper || otherMove is Spock;
}
