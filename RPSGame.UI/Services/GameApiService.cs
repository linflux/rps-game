using System.Net.Http.Json;
using RPSGame.Domain.Entities;
using RPSGame.Domain.Enums;
using RPSGame.Application.Entities;

namespace RPSGame.UI.Services
{
    /// <summary>
    /// Service to interact with the Game API.
    /// </summary>
    /// <remarks>
    /// This service is responsible for making HTTP requests to the Game API.
    /// It provides methods to set the game level, player name, get available moves,
    /// get the computer's move, and play a game round.
    /// </remarks>
    public class GameApiService
    {
        private readonly HttpClient _httpClient;

        public GameApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SetGameLevel(GameLevel level)
        {
            await _httpClient.PostAsJsonAsync("Game/SetGameLevel", level);
        }

        public async Task SetPlayerName(string playerName)
        {
            var response = await _httpClient.PostAsJsonAsync("Game/SetPlayerName", playerName);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to set player name: {response.ReasonPhrase}");
            }
        }

        public async Task<string> GetPlayerName()
        {
            return await _httpClient.GetStringAsync("Game/GetPlayerName");
        }

        public async Task<List<ConcreteMove>> GetAvailableMoves()
        {
            return await _httpClient.GetFromJsonAsync<List<ConcreteMove>>("Game/GetAvailableMoves");
        }

        public async Task<ConcreteMove> GetMove(string moveName)
        {
            // Construct the URL with the query parameter
            var response = await _httpClient.GetAsync($"Game/GetMove?moveName={Uri.EscapeDataString(moveName)}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ConcreteMove>();
            }
            else
            {
                throw new Exception($"Failed to get move: {response.ReasonPhrase}");
            }
        }
        
        public async Task<ConcreteMove> GetComputerMove()
        {
            return await _httpClient.GetFromJsonAsync<ConcreteMove>("Game/GetComputerMove");
        }

        public async Task<GamePlayResult> Play(string playerMove, string computerMove)
        {
            var request = new
            {
                PlayerMove = playerMove,
                ComputerMove = computerMove
            };

            var response = await _httpClient.PostAsJsonAsync("Game/Play", request);
            return await response.Content.ReadFromJsonAsync<GamePlayResult>();
        }
    }
}
