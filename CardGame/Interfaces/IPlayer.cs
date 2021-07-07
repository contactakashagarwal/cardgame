using System.Collections.Generic;
using CardGame.Models;

namespace CardGame.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        Card LastDrawnCard { get; }
        int DrawPileCount { get;}
        int DiscardPileCount { get; }

        bool TryDrawCard(out Card card);
        void AddCardsToDiscardPile(List<Card> cards);
        void AssignCards(List<Card> cards);
    }
}
