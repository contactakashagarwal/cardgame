using System;
using CardGame.Factories;
using CardGame.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CardGame
{
    class Program
    {
        private static readonly ICardGameControllerFactory _cardGameFactory;
        private const int _deckSize = 40;
        private const int numOfPlayers = 2; 

        static Program()
        {
            var serviceProvider = SetupDependency();
            _cardGameFactory = serviceProvider.GetService<ICardGameControllerFactory>();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To cards game !!!");
            Console.Write("Enter player 1 name - ");
            var player1Name = Console.ReadLine();

            Console.Write("Enter player 2 name - ");
            var player2Name = Console.ReadLine();

            var game = _cardGameFactory.Create(_deckSize, numOfPlayers);
            game.Start(player1Name, player2Name);
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
