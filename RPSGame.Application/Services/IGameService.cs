using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;

namespace RPSGame.Application.Services
{
    public interface IGameService
    {
        Player Player { get; }
        Player Computer { get; }

        List<Move> GetAvailableMoves(GameLevel level);

        Move GetMove(string moveName);

        Move GetComputerMove();
        
        int GetComputerScore();
        int GetPlayerScore();
        
        GamePlayResult Play(string playerMoveName, string opponentMoveName);
        void SetGameLevel(GameLevel level);
        void SetPlayers(string playerName);
    }
}