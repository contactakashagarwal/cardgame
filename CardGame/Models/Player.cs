using System.Collections.Generic;
using CardGame.Interfaces;
using CardGame.Utility;

namespace CardGame.Models
{
    public class Player : IPlayer
    {
        private readonly string _name;
        private readonly Stack<Card> _drawPile;
        private readonly List<Card> _discardPile;
        private Card _lastDrawnCard;

        public Player(string name)
        {
            _name = name;
            _drawPile = new Stack<Card>();
            _discardPile = new List<Card>();
            _lastDrawnCard = null;
        }

        public string Name => _name;
        public Card LastDrawnCard => _lastDrawnCard;
        public int DrawPileCount => _drawPile.Count;
        public int DiscardPileCount => _discardPile.Count;

        /// <summary>
        /// Tries to draw top card from the draw pile of player and assign it to LastDrawnCard, assigns null if there are no cards
        /// </summary>
        /// <param name="card"></param>
        public void TryDrawCard()
        {
            if (!IsDrawPileEmpty)
            {
                _lastDrawnCard = PopTopCardFromDrawPile;
            }
            else if(!IsDiscardPileEmpty)
            {
                //flush discard pile into draw pile
                ShuffleAndFlushDiscardPile();
                _lastDrawnCard =  PopTopCardFromDrawPile;
            }
            else
            {
                _lastDrawnCard = null;
            }
        }

        /// <summary>
        /// Assign the first set of cards to player to be added in Draw pile
        /// </summary>
        /// <param name="cards"></param>
        public void AssignCards(List<Card> cards)
        {
            cards.ForEach(card => _drawPile.Push(card));
        }

        /// <summary>
        /// Add cards to discard pile
        /// </summary>
        /// <param name="cards"></param>
        public void AddCardsToDiscardPile(List<Card> cards)
        {
            _discardPile.AddRange(cards);
        }

        /// <summary>
        /// Shuffles the discard pile and move shuffled cards from discard pile to draw pile
        /// </summary>
        private void ShuffleAndFlushDiscardPile()
        {
            _discardPile.Shuffle();
            _discardPile.ForEach(card => _drawPile.Push(card));
            _discardPile.Clear();
        }

        private Card PopTopCardFromDrawPile => _drawPile.Pop();
        private bool IsDrawPileEmpty => _drawPile.Count == 0;
        private bool IsDiscardPileEmpty => _discardPile.Count == 0;
    }
}
