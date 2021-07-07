using CardGame.Interfaces;

namespace CardGame.Factories
{
    public interface IDeckFactory
    {
        public IDeck Create(int deckSize);
    }
}
