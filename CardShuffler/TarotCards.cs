using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardShuffler
{
    //Database
    public class TarotCards : BaseCards
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public new enum Rank
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
            Page,
            Knave,
            Queen,
            King
        }

        public new class Card
        {
            public Suit CardSuit { get; set; }
            public Rank CardRank { get; set; }
            public Card(Suit s, Rank v)
            {
                CardSuit = s;
                CardRank = v;
            }
        }

        public static string RankMeaning(Card cardToTranslate)
        {
            string rankMeaning = "";

            switch (cardToTranslate.CardSuit)
            {
                case Suit.Cups:
                    rankMeaning = cardToTranslate.CardRank + " of Cups: " + ((TarotCards.Cups)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Pentacles:
                    rankMeaning = cardToTranslate.CardRank + " of Pentacles: " + ((TarotCards.Pentacles)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Wands:
                    rankMeaning = cardToTranslate.CardRank + " of Wands: " + ((TarotCards.Wands)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Swords:
                    rankMeaning = cardToTranslate.CardRank + " of Swords: " + ((TarotCards.Swords)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                default:
                    break;
            }

            return rankMeaning;
        }
    }
}

