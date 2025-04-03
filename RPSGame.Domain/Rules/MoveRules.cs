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
                { "Rock", new List<string> { "Scissors", "Lizard", "Sponge", "Fire", "Snake", "Human", "Wolf" } },
                { "Paper", new List<string> { "Rock", "Spock", "Dragon", "Tree", "Water", "Air", "Lightning" } },
                { "Scissors", new List<string> { "Paper", "Lizard", "Dragon", "Snake", "Human", "Tree", "Sponge" },

                // Intermediate Moves
                { "Lizard", new List<string> { "Spock", "Paper", "Tree", "Air", "Water", "Dragon", "Wolf" } },
                { "Spock", new List<string> { "Scissors", "Rock", "Fire", "Lightning", "Gun", "Dragon", "Snake" } },

                // Hard Moves
                { "Gun", new List<string> { "Rock", "Devil", "Air", "Tree", "Wolf", "Snake", "Sponge" } },
                { "Lightning", new List<string> { "Water", "Sponge", "Devil", "Dragon", "Human", "Tree", "Paper" } },
                { "Devil", new List<string> { "Sponge", "Fire", "Air", "Rock", "Scissors", "Wolf", "Dragon" } },
                { "Water", new List<string> { "Fire", "Sponge", "Gun", "Paper", "Lizard", "Snake", "Human" } },
                { "Air", new List<string> { "Fire", "Sponge", "Lightning", "Rock", "Scissors", "Dragon", "Wolf" } },
                { "Sponge", new List<string> { "Water", "Gun", "Rock", "Paper", "Lizard", "Tree", "Human" } },
                { "Fire", new List<string> { "Rock", "Sponge", "Devil", "Scissors", "Snake", "Wolf", "Dragon" } },
                { "Dragon", new List<string> { "Wolf", "Tree", "Snake", "Gun", "Air", "Lightning", "Paper" } },
                { "Tree", new List<string> { "Paper", "Human", "Sponge", "Water", "Lizard", "Gun", "Scissors" } },
                { "Human", new List<string> { "Snake", "Scissors", "Gun", "Rock", "Fire", "Lightning", "Dragon" } },
                { "Wolf", new List<string> { "Human", "Tree", "Paper", "Lizard", "Air", "Gun", "Fire" } },
                { "Snake", new List<string> { "Dragon", "Wolf", "Lizard", "Spock", "Paper", "Lightning", "Gun" } }
            };
        }

        public bool Beats(string move, string opponentMove)
        {
            return _rules.ContainsKey(move) && _rules[move].Contains(opponentMove);
        }
    }
}
