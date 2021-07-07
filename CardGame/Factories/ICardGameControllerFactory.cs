using CardGame.Interfaces;

namespace CardGame.Factories
{
    public interface ICardGameControllerFactory
    {
        public ICardGameController Create(int deckSize, int numOfPlayers);
    }
}
