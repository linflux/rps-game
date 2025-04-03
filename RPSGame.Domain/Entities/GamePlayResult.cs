using RPSGame.Domain.Enums;

namespace RPSGame.Domain.Entities
{
    public class GamePlayResult
    {
        public string Message { get; set; }
        public string ScoreMessage { get; set; }
        public MoveResult MoveResult { get; set; }
        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }
    }
}