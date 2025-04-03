using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;


namespace RPSGame.Application.Factories
{
    public static class MoveFactory
    {
        public static List<Move> GetMoves(GameLevel level)
        {
            return level switch
            {
                GameLevel.Easy => new List<Move>
                {
                    new Rock(),
                    new Paper(),
                    new Scissors()
                },
                GameLevel.Intermediate => new List<Move>
                {
                    new Rock(),
                    new Paper(),
                    new Scissors(),
                    new Lizard(),
                    new Spock()
                },
                GameLevel.Hard => new List<Move>
                {
                    new Rock(),
                    new Paper(),
                    new Scissors(),
                    // new Lizard(),
                    // new Spock(),
                    new Gun(),
                    new Lightning(),
                    new Devil(),
                    new Dragon(),
                    new Water(),
                    new Air(),
                    new Sponge(),
                    new Wolf(),
                    new Tree(),
                    new Human(),
                    new Snake(),
                    new Fire()
                },
                _ => throw new ArgumentException("Invalid game level")
            };
        }
    
        public static Move CreateMove(string moveName, List<Move> availableMoves)
        {
            var move = availableMoves.FirstOrDefault(m => m.Name.Equals(moveName, StringComparison.OrdinalIgnoreCase));

            if (move == null)
            {
                throw new ArgumentException($"Move '{moveName}' is not valid.");
            }

            return move;
        }

    }
}
