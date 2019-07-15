using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardShuffler
{
    //Database
    public class TarotCards
    {
        public enum Suit
        {
            Cups,
            Pentacles,
            Wands,
            Swords
        }

        public enum Cups
        {
            [Description("Ace of Cups: New love or closer relationship")]
            Ace,
            [Description("Two: Union of people, ideas, or talents")]
            Two,
            [Description("Three: connection")]
            Three,
            [Description("Four: opportunity that should not be missed")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Knave,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Pentacles
        {
            [Description("")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Jack,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Wands
        {
            [Description("Ace of Wands: New Inspiration and Mental Energy")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Jack,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Swords
        {
            [Description("")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("Knave of Swords: Someone on a mission")]
            Knave,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public class Card
        {
            public Suit CardSuit { get; set; }
            public int CardRank { get; set; }
            public Card(Suit s, int v)
            {
                CardSuit = s;
                CardRank = v;
            }
        }

        public List<Card> Cards { get; set; }

        public TarotCards()
        {
            Cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                //loop each tarot card in the deck
                switch (suit)
                {
                    case Suit.Cups:
                        foreach(Cups cup in Enum.GetValues(typeof(Cups)))
                            Cards.Add(new Card(suit, (int)cup));
                        break;
                    case Suit.Pentacles:
                        foreach (Pentacles pentacle in Enum.GetValues(typeof(Pentacles)))
                            Cards.Add(new Card(suit, (int)pentacle));
                        break;
                    case Suit.Swords:
                        foreach (Swords sword in Enum.GetValues(typeof(Swords)))
                            Cards.Add(new Card(suit, (int)sword));
                        break;
                    case Suit.Wands:
                        foreach (Wands wand in Enum.GetValues(typeof(Wands)))
                            Cards.Add(new Card(suit, (int)wand));
                        break;
                }
            }
        }

        public static string RankMeaning(Card cardToTranslate)
        {
            string rankMeaning = "";

            switch (cardToTranslate.CardSuit)
            {
                case Suit.Cups:
                    rankMeaning = ((TarotCards.Cups)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Pentacles:
                    rankMeaning = ((TarotCards.Pentacles)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Wands:
                    rankMeaning = ((TarotCards.Wands)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Swords:
                    rankMeaning = ((TarotCards.Swords)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                default:
                    break;
            }

            return rankMeaning;
        }
    }
}
