using System;
using CardGame.Interfaces;
using CardGame.Models;

namespace CardGame.Factories
{
    public class DeckFactory : IDeckFactory
    {
        public IDeck Create(int deckSize)
        {
            return new Deck(deckSize);
        }
    }
}
