namespace CardGame.Models
{
    public class Card
    {
        public Card(int number)
        {
            Number = number;
        }

        public int Number { get; }

        /// <summary>
        /// Compares value of two cards and returns the greater card
        /// </summary>
        /// <param name="card2"></param>
        /// <returns>Returns null if both cards have same value</returns>
        public Card Compare(Card card2)
        {
            return Number == card2.Number ? null : (Number > card2.Number) ? this : card2;
        }
    }
}   
