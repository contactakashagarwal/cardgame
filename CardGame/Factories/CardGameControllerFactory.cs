using System;
using CardGame.Interfaces;

namespace CardGame.Factories
{
    public class CardGameControllerFactory : ICardGameControllerFactory
    {
        private readonly IDeckFactory _deckFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly ICommandLineIO _commandLineIO;

        public CardGameControllerFactory(IDeckFactory deckFactory, IPlayerFactory playerFactory, ICommandLineIO commandLineIO)
        {
            _deckFactory = deckFactory;
            _playerFactory = playerFactory;
            _commandLineIO = commandLineIO;
        }

        public ICardGameController Create(int deckSize, int numberOfPlayers)
        {
            return new CardGameController(_deckFactory.Create(deckSize), _playerFactory, _commandLineIO, numberOfPlayers);
        }
    }
}
