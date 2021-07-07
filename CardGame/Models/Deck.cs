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

        public Deck(int deckSize)
        {
            _deckSize = deckSize;
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

        public IEnumerable<Card> GetHalfDeck()
        {
            int halfDeckCount = _deckSize / 2;
            if (_cards.Count >= halfDeckCount)
            {
                var halfDeck = new List<Card>();
                halfDeck.AddRange(_cards.Take(halfDeckCount));
                _cards.RemoveRange(0, halfDeckCount);
                return halfDeck;
            }

            throw new Exception("Not enough cards in deck");
        }

        public void Shuffle()
        {
            _cards.Shuffle();
        }
    }
}
