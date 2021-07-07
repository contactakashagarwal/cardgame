using CardGame.Models;
using NUnit.Framework;

namespace CardGame.Tests
{
    public class CardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Compare_returns_card_with_higher_value_on_comparing_two_cards_of_differnt_value()
        {
            Card card1 = new Card(5);
            Card card2 = new Card(4);

            var winingCard = card1.Compare(card2);

            Assert.AreEqual(card1, winingCard);
        }

        [Test]
        public void Compare_returns_null_on_comparing_two_cards_of_same_value()
        {
            Card card1 = new Card(5);
            Card card2 = new Card(5);

            var winingCard = card1.Compare(card2);

            Assert.AreEqual(null, winingCard);
        }
    }
}
