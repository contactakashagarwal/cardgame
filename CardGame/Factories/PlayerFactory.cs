using CardGame.Interfaces;
using CardGame.Models;

namespace CardGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(string name)
        {
            return new Player(name);
        }
    }
}
