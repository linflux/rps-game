using RPSGame.Domain.Entities;
using RPSGame.Domain.Interfaces;
using RPSGame.Infrastructure.Services;
using RPSGame.Application.Services;
using RPSGame.Application.Factories;

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    private static readonly Random _random = new Random();

    static void Main(string[] args)
    {
        // Set up dependency injection
        var gameService = ConfigureServices();

        // Start the game
        StartGame(gameService);
    }

    private static GameService ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMoveEvaluator, DefaultMoveEvaluator>()
            .AddSingleton<GameService>()
            .BuildServiceProvider();

        var gameService = serviceProvider.GetService<GameService>();
        if (gameService == null)
        {
            throw new InvalidOperationException("GameService is not configured in the service provider.");
        }

        return gameService;
    }

    private static void StartGame(GameService gameService)
    {
        // Select game level
        var level = SelectGameLevel();
        gameService.SetGameLevel(level);

        // Set players in game service
        var playerName = GetPlayerName();
        gameService.SetPlayers(playerName);

        // Get and display available moves
        var availableMoves = gameService.GetAvailableMoves();
        DisplayAvailableMoves(availableMoves);

        // Determine the number of rounds
        int totalRounds = GetTotalRounds();

        // Play the game
        PlayRounds(gameService, availableMoves, totalRounds);

        // Display final scores
        DisplayFinalScores(gameService);
    }

    private static GameLevel SelectGameLevel()
    {
        Console.WriteLine("Select Game Level: Easy (1), Intermediate (2), Hard (3)");
        var levelInput = Console.ReadLine();

        return levelInput switch
        {
            "1" => GameLevel.Easy,
            "2" => GameLevel.Intermediate,
            "3" => GameLevel.Hard,
            _ => throw new ArgumentException("Invalid level selected!")
        };
    }

    private static void DisplayAvailableMoves(List<Move> availableMoves)
    {
        Console.WriteLine("Available moves:");
        foreach (var move in availableMoves)
        {
            Console.WriteLine($"- {move.Name}");
        }
    }

    private static int GetTotalRounds()
    {
        Console.WriteLine("How many rounds would you like to play? (e.g., 3, 5, 10)");
        if (int.TryParse(Console.ReadLine(), out int totalRounds) && totalRounds > 0)
        {
            return totalRounds;
        }

        Console.WriteLine("Invalid input. Exiting...");
        Environment.Exit(0);
        return 0; // This will never execute due to `Environment.Exit`, but it satisfies the compiler.
    }

    private static void PlayRounds(GameService gameService, List<Move> availableMoves, int totalRounds)
    {
        for (int currentRound = 1; currentRound <= totalRounds; currentRound++)
        {
            Console.WriteLine($"\nRound {currentRound} of {totalRounds}");

            // Get player move
            var playerMoveName = GetPlayerMove(availableMoves);

            // Computer move
            var computerMove = GetComputerMove(availableMoves);
            Console.WriteLine($"Computer chose: {computerMove.Name}");
            AsciiArtService.DisplayMoveArt(computerMove.Name);

            // Play the round
            var result = gameService.Play(playerMoveName, computerMove.Name);
            Console.WriteLine(result);

            // Display current scores
            DisplayCurrentScores(gameService);
        }
    }

    private static string GetPlayerName()
    {
        // Request player's name
        Console.WriteLine("Enter your name:");
        var playerName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(playerName))
        {
            Console.WriteLine("Invalid name. Exiting...");
            return string.Empty;
        }

        return playerName;
    }

    private static string GetPlayerMove(List<Move> availableMoves)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter your move:");
                string moveName = Console.ReadLine();
                var move = MoveFactory.CreateMove(moveName, availableMoves);
                AsciiArtService.DisplayMoveArt(move.Name);
                return move.Name; // Returns the move's name
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid move. Try again:");
            }
        }
    }

    private static Move GetComputerMove(List<Move> availableMoves)
    {
        return availableMoves[_random.Next(availableMoves.Count)];
    }

    private static void DisplayCurrentScores(GameService gameService)
    {
        Console.WriteLine($"Scores: Player {gameService.Player.Name} - {gameService.GetPlayerScore()}, Computer - {gameService.GetComputerScore()}");
    }

    private static void DisplayFinalScores(GameService gameService)
    {
        Console.WriteLine("\nGame Over!");
        Console.WriteLine($"Final Scores: Player {gameService.Player.Name} - {gameService.GetPlayerScore()}, Computer - {gameService.GetComputerScore()}");
        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}


// Console.WriteLine("Enter your move:");
// var playerMove = Console.ReadLine();

// // Random opponent move for demonstration
// var opponentMove = gameService.GetAvailableMoves()[new Random().Next(gameService.GetAvailableMoves().Count)].Name;
// Console.WriteLine($"Computer chose: {opponentMove}");

// if (!string.IsNullOrEmpty(playerMove))
//     Console.WriteLine(gameService.Play(playerMove, opponentMove));
