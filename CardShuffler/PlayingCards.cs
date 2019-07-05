using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardShuffler
{
    //Database
    public class PlayingCards
    {
        public enum Suit
        {
            [Description("TarotDeck.Cups")]
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum Rank
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public class Card
        {
            public Suit CardSuit { get; set; }
            public Rank CardRank { get; set; }
            public Card(Suit s, Rank v)
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
                    Cards.Add(new Card(suit, (Rank)y));
                }
            }
        }

        public static string RankMeaning(Card cardToTranslate)
        {
            string rankMeaning = "";

            switch (cardToTranslate.CardSuit)
            {
                case Suit.Hearts:
                    rankMeaning = ((TarotDeck.Cups)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Diamonds:
                    rankMeaning = ((TarotDeck.Pentacles)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Clubs:
                    rankMeaning = ((TarotDeck.Wands)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Spades:
                    rankMeaning = ((TarotDeck.Swords)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                default:
                    break;
            }

            return rankMeaning;
        }
    }
}
