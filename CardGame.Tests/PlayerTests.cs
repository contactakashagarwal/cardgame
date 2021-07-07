using System.Collections.Generic;
using CardGame.Interfaces;
using CardGame.Models;
using NUnit.Framework;

namespace CardGame.Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void If_Player_with_an_empty_draw_pile_tries_to_draw_card_Then_discard_pile_is_shuffled_into_draw_pile()
        {
            IPlayer player = new Player("player");
            var cards = new List<Card> { new Card(1), new Card(2) };
            player.AddCardsToDiscardPile(cards);

            Assert.AreEqual(0, player.DrawPileCount);

            player.TryDrawCard(out var card);

            Assert.AreEqual(0, player.DiscardPileCount);
            Assert.AreEqual(1, player.DrawPileCount);
        }

        [Test]
        public void If_Player_has_card_in_draw_pile_then_top_card_from_draw_pile_is_returned()
        {
            IPlayer player = new Player("player");
            var cards = new List<Card> { new Card(1), new Card(2) };
            player.AssignCards(cards);
            Assert.AreEqual(2, player.DrawPileCount);
            player.TryDrawCard(out var topCard);

            Assert.AreEqual(cards[1], topCard);
            Assert.AreEqual(1, player.DrawPileCount);
        }

        [Test]
        public void If_Player_has_no_card_in_either_of_draw_pile_and_discard_pile_then_tryDrawCard_outputs_null_and_returns_false()
        {
            IPlayer player = new Player("player");
            var isCardDrawn = player.TryDrawCard(out var topCard);

            Assert.That(isCardDrawn, Is.False);
            Assert.That(topCard, Is.Null);
        }
    }
}
