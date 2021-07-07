using CardGame.Interfaces;

namespace CardGame.Factories
{
    public interface IPlayerFactory
    {
        public IPlayer Create(string name);
    }
}
