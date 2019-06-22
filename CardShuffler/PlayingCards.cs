using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardShuffler
{
    public class PlayingCards
    {
        public enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public class Card
        {
            public Suit CardSuit { get; set; }
            public string CardRank { get; set; }
            public Card(Suit s, string v)
            {
                CardSuit = s;
                CardRank = v;
            }
        }

        public List<Card> Cards { get; set; }

        public PlayingCards()
        {
            Cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int y = 1; y < 14; y++)
                {
                    Cards.Add(new Card(suit, y.ToString()));
                }
            }
        }
    }
}
