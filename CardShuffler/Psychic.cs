using System;
using System.ComponentModel;

namespace CardShuffler
{
    public static class Psychic
    {
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

        public static string TranslateCard(PlayingCards.Card cardToTranslate)
        {
            string rankMeaning = PlayingCards.RankMeaning(cardToTranslate);
            return rankMeaning;
        }

        public static string TranslateCard(TarotCards.Card cardToTranslate)
        {
            string rankMeaning = TarotCards.RankMeaning(cardToTranslate);
            return rankMeaning;
        }
    }
}
