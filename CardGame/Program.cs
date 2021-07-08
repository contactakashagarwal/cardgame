using System;
using System.Collections.Generic;
using CardGame.Factories;
using CardGame.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CardGame
{
    class Program
    {
        private static readonly ICardGameControllerFactory _cardGameFactory;
        private const int _deckSize = 40; //should be in multiple of 4
        private const int numOfPlayers = 2; //currently this game is supported for only 2 players

        static Program()
        {
            var serviceProvider = SetupDependency();
            _cardGameFactory = serviceProvider.GetService<ICardGameControllerFactory>();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To cards game !!!");

            List<string> playerNames = new List<string>();

            for(int playerNum = 1; playerNum <= numOfPlayers; playerNum++)
            {
                Console.Write($"Enter player {playerNum} name - ");
                playerNames.Add(Console.ReadLine());
            }
            
            var game = _cardGameFactory.Create(_deckSize, numOfPlayers);
            game.Start(playerNames);
        }

        private static ServiceProvider SetupDependency()
        {
            return new ServiceCollection()
                 .AddSingleton<ICardGameControllerFactory, CardGameControllerFactory>()
                 .AddSingleton<IPlayerFactory, PlayerFactory>()
                 .AddSingleton<IDeckFactory, DeckFactory>()
                 .AddSingleton<ICommandLineIO, CommandLineIO>()
                 .BuildServiceProvider();
        }
    }
}
