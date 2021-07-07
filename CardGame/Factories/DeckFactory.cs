using System;
using CardGame.Interfaces;
using CardGame.Models;

namespace CardGame.Factories
{
    public class DeckFactory : IDeckFactory
    {
        public IDeck Create(int deckSize, int numberOfPlayers)
        {
            return new Deck(deckSize, numberOfPlayers);
        }
    }
}
