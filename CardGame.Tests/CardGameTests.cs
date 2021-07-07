using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CardGame.Factories;
using CardGame.Models;
using CardGame.Interfaces;

namespace CardGame.Tests
{
    public class CardGameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_comparing_two_cards_of_same_value_winner_of_next_round_should_win_four_cards()
        {
            //setting cards in deck such that first cards of both players will be same and next card of player 2 will be higher in value.
            var cards = new List<Card> { new Card(2), new Card(1), new Card(3), new Card(1) };

            var deck = new Mock<IDeck>();
            deck.Setup(d => d.Cards).Returns(cards);
            deck.Setup(d => d.DeckSize).Returns(4);
            deck.SetupSequence(d => d.GetHalfDeck())
                .Returns(new List<Card> {cards[0], cards[1] })
                .Returns(new List<Card> { cards[2], cards[3] });

            var player1 = new Player("p1");
            var player2 = new Player("p2");
            
            var playerFactory = new Mock<IPlayerFactory>();
            playerFactory.Setup(f => f.Create("p1")).Returns(player1);
            playerFactory.Setup(f => f.Create("p2")).Returns(player2);

            var commandLineIO = new Mock<ICommandLineIO>();
            var cardGame = new CardGameController(deck.Object, playerFactory.Object,commandLineIO.Object, 2);
            cardGame.Start("p1", "p2");

            //all four cards would be won by player2 and would be sitting in player's discard pile because the game has ended and he won
            Assert.AreEqual(4, player2.DiscardPileCount);
        }
    }
}
