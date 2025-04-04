using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;
using RPSGame.Domain.Interfaces;

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
        
        void SetGameLevel(GameLevel level);
        void SetPlayer(string playerName);
        string GetPlayerName();
        
        GamePlayResult Play(string playerMoveName, string opponentMoveName);

    }
}