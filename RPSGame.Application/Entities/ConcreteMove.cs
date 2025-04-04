using RPSGame.Domain.Entities;

namespace RPSGame.Application.Entities
{
    public class ConcreteMove : Move
    {
        public string Name { get; set; }

        public ConcreteMove(string name) : base(name)
        {
            Name = name;
        }

        public override bool Beats(Move otherMove)
        {
            // Implement the logic to determine if this move beats the other move
            // For example, if this is Rock and the other move is Scissors, return true
            // This is just a placeholder implementation
            return false;
        }
    }
}