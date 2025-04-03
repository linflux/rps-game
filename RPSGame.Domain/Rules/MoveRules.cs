using RPSGame.Domain.Entities;

namespace RPSGame.Domain.Rules
{
    public class MoveRules
    {
        private readonly Dictionary<string, List<string>> _rules;

        public MoveRules()
        {
            _rules = new Dictionary<string, List<string>>
            {
                // Easy Moves
                { "Rock", new List<string> { "Scissors", "Lizard" } },
                { "Paper", new List<string> { "Rock", "Spock" } },
                { "Scissors", new List<string> { "Paper", "Lizard" } },

                // Intermediate Moves
                { "Lizard", new List<string> { "Spock", "Paper" } },
                { "Spock", new List<string> { "Scissors", "Rock" } },

                // Hard Moves
                { "Gun", new List<string> { "Rock", "Devil", "Air" } },
                { "Lightning", new List<string> { "Water", "Sponge", "Devil" } },
                { "Devil", new List<string> { "Sponge", "Fire", "Air" } },
                { "Water", new List<string> { "Fire", "Sponge", "Gun" } },
                { "Air", new List<string> { "Fire", "Sponge", "Lightning" } },
                { "Sponge", new List<string> { "Water", "Gun", "Rock" } },
                { "Fire", new List<string> { "Rock", "Sponge", "Devil" } },
                { "Dragon", new List<string> { "Wolf", "Tree", "Snake" } },
                { "Tree", new List<string> { "Paper", "Human", "Sponge" } },
                { "Human", new List<string> { "Snake", "Scissors", "Gun" } },
                { "Wolf", new List<string> { "Human", "Tree", "Paper" } },
                { "Snake", new List<string> { "Dragon", "Wolf", "Lizard" } }
            };
        }

        public bool Beats(string move, string opponentMove)
        {
            return _rules.ContainsKey(move) && _rules[move].Contains(opponentMove);
        }
    }
}
