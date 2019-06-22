using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static CardShuffler.TarotDeck;

namespace CardShuffler
{
    public static class Psychic
    {
        public static string TranslateCard(PlayingCards.Card cardToTranslate)
        {
            //figure out the suit
            int suitLocation = (int)cardToTranslate.CardSuit;
            var suiteMeaning = (Suit)suitLocation;
            var rankMeaning = "";

            int.TryParse(cardToTranslate.CardRank, out int rankLocation);

            switch (suiteMeaning)
            {
                case Suit.Cups:
                    rankMeaning = ((Cups)(rankLocation - 1)).GetRankDescription();
                    break;
                case Suit.Pentacles:
                    rankMeaning = ((Pentacles)(rankLocation - 1)).GetRankDescription();
                    break;
                case Suit.Swords:
                    rankMeaning = ((Swords)(rankLocation - 1)).GetRankDescription();
                    break;
                case Suit.Wands:
                    rankMeaning = ((Wands)(rankLocation - 1)).GetRankDescription();
                    break;
            }

            return rankMeaning;
        }
        
        public static string GetRankDescription(this Object enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
   }
}
