using System.Collections.Generic;
using CardGame.Models;

namespace CardGame.Interfaces
{
    public interface IDeck
    {
        IEnumerable<Card> Cards { get; }
        int DeckSize { get; }
        IEnumerable<Card> GetHalfDeck();
        void Shuffle();
    }
}
    