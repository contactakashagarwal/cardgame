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
            var playerNames = new List<string> { "p1", "p2" };

            var deck = new Mock<IDeck>();
            deck.Setup(d => d.Cards).Returns(cards);
            deck.Setup(d => d.DeckSize).Returns(4);
            deck.SetupSequence(d => d.GetCardsForPlayer())
                .Returns(new List<Card> {cards[0], cards[1] })
                .Returns(new List<Card> { cards[2], cards[3] });

            var player1 = new Player(playerNames[0]);
            var player2 = new Player(playerNames[1]);
            
            var playerFactory = new Mock<IPlayerFactory>();
            playerFactory.Setup(f => f.Create(playerNames[0])).Returns(player1);
            playerFactory.Setup(f => f.Create(playerNames[1])).Returns(player2);

            var commandLineIO = new Mock<ICommandLineIO>();
            var cardGame = new CardGameController(deck.Object, playerFactory.Object,commandLineIO.Object);
            cardGame.Start(playerNames);

            // the game ended now since player 1 has zero cards
            // all four cards would be won by player2,
            // in next round player2's discard pile is flushed into draw pile and top card is drawn and thrown on board
            // hence draw pile of player 2 is having 3 cards and discard pile is having 0 card.
            Assert.AreEqual(3, player2.DrawPileCount);
            Assert.AreEqual(0, player2.DiscardPileCount);
        }
    }
}
