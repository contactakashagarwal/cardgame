using System;
using System.Collections.Generic;
using CardGame.Utility;
using System.Linq;
using CardGame.Interfaces;

namespace CardGame.Models
{
    public class Deck : IDeck
    {
        private List<Card> _cards;
        private readonly int _deckSize;
        private readonly int _numberOfPlayers;

        public Deck(int deckSize, int numberOfPlayers)
        {
            _deckSize = deckSize;
            _numberOfPlayers = numberOfPlayers;
            _cards = new List<Card>();
            Initialize();

            //shuffling the deck after initializing cards using Fisher yates shuffle algorithm
            Shuffle();
        }

        private void Initialize()
        {
            for(int num = 1; num <= _deckSize / 4 ; num++)
            {
                var card = new Card(num);

                //adding each numbered card 4 times in the deck
                for(int i = 0; i < 4; i++)
                {
                    _cards.Add(card);
                }
            }
        }

        public IEnumerable<Card> Cards => _cards;
        public int DeckSize => _deckSize;

        public void Shuffle()
        {
            _cards.Shuffle();
        }

        public List<Card> GetCardsForPlayer()
        {
            int cardsCountForEachPlayer = _deckSize / _numberOfPlayers;
            if(_cards.Count >= cardsCountForEachPlayer)
            {
                var cards = new List<Card>();
                cards.AddRange(_cards.Take(cardsCountForEachPlayer));
                _cards.RemoveRange(0, cardsCountForEachPlayer);
                return cards;
            }

            throw new Exception("Not enough cards in deck");
        }
    }
}
