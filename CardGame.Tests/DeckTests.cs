using System.Collections.Generic;
using System.Linq;
using CardGame.Models;
using NUnit.Framework;

namespace CardGame.Tests
{
    public class DeckTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void New_deck_should_contain_40_cards()
        {
            Deck deck = new Deck(40);
            Assert.AreEqual(40, deck.Cards.Count());
        }

        [Test]
        public void Shuffle_deck_should_shuffle_the_deck_such_that_same_cards_should_be_there_in_deck_but_with_different_order()
        {
            Deck deck = new Deck(40);
            //storing original order of deck in a new listß
            var originalDeck = new List<Card>();
            deck.Cards.ToList().ForEach(card => originalDeck.Add(card));

            deck.Shuffle();

            //checking if same cards are there in deck
            CollectionAssert.AreEquivalent(deck.Cards, originalDeck);

            //checking if order is differnt
            CollectionAssert.AreNotEqual(deck.Cards, originalDeck);
        }

    }
}
