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
                for (int y = 1; y < 14; y++)
                {
                    Cards.Add(new Card(suit, y));
                }
            }
        }

        public static string RankMeaning(Card cardToTranslate)
        {
            return null;
        }
    }
}
