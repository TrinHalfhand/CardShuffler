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

            //Rank is specifically translated for the face cards since there is no page card in a playing card deck.
            switch (cardToTranslate.CardSuit)
            {
                case Suit.Hearts:
                    if (cardToTranslate.CardRank == Rank.Jack)
                        rankMeaning = "Knave of Cups: ";
                    else
                        rankMeaning = cardToTranslate.CardRank + " of Cups: ";

                    switch ( cardToTranslate.CardRank )
                    {
                        case Rank.Jack:
                            rankMeaning += (TarotCards.Cups.Knave).GetRankDescription();
                            break;
                        case Rank.Queen:
                            rankMeaning += (TarotCards.Cups.Queen).GetRankDescription();
                            break;
                        case Rank.King:
                            rankMeaning += (TarotCards.Cups.King).GetRankDescription();
                            break;
                        default:
                            rankMeaning += ((TarotCards.Cups)(cardToTranslate.CardRank)).GetRankDescription();
                            break;
                    }
                    break;
                case Suit.Diamonds:
                    if (cardToTranslate.CardRank == Rank.Jack)
                        rankMeaning = "Knave of Pentacles: ";
                    else
                        rankMeaning = cardToTranslate.CardRank + " of Pentacles: ";

                    switch (cardToTranslate.CardRank)
                    {
                        case Rank.Jack:
                            rankMeaning += (TarotCards.Pentacles.Knave).GetRankDescription();
                            break;
                        case Rank.Queen:
                            rankMeaning += (TarotCards.Pentacles.Queen).GetRankDescription();
                            break;
                        case Rank.King:
                            rankMeaning += (TarotCards.Pentacles.King).GetRankDescription();
                            break;
                        default:
                            rankMeaning += ((TarotCards.Pentacles)(cardToTranslate.CardRank)).GetRankDescription();
                            break;
                    }
                    break;
                case Suit.Clubs:
                    if (cardToTranslate.CardRank == Rank.Jack)
                        rankMeaning = "Knave of Wands: ";
                    else
                        rankMeaning = cardToTranslate.CardRank + " of Wands: ";

                    switch (cardToTranslate.CardRank)
                    {
                        case Rank.Jack:
                            rankMeaning += (TarotCards.Wands.Knave).GetRankDescription();
                            break;
                        case Rank.Queen:
                            rankMeaning += (TarotCards.Wands.Queen).GetRankDescription();
                            break;
                        case Rank.King:
                            rankMeaning += (TarotCards.Wands.King).GetRankDescription();
                            break;
                        default:
                            rankMeaning += ((TarotCards.Wands)(cardToTranslate.CardRank)).GetRankDescription();
                            break;
                    }
                    break;
                case Suit.Spades:
                    if (cardToTranslate.CardRank == Rank.Jack)
                        rankMeaning = "Knave of Swords: ";
                    else
                        rankMeaning = cardToTranslate.CardRank + " of Swords: ";

                    switch (cardToTranslate.CardRank)
                    {
                        case Rank.Jack:
                            rankMeaning += (TarotCards.Swords.Knave).GetRankDescription();
                            break;
                        case Rank.Queen:
                            rankMeaning += (TarotCards.Swords.Queen).GetRankDescription();
                            break;
                        case Rank.King:
                            rankMeaning += (TarotCards.Swords.King).GetRankDescription();
                            break;
                        default:
                            rankMeaning += ((TarotCards.Swords)(cardToTranslate.CardRank)).GetRankDescription();
                            break;
                    }
                    break;
                default:
                    break;
            }

            return rankMeaning;
        }
    }
}
