using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler
{
    //DAL
    public class StandardTarotDeck : IDeckInterface<TarotCards.Card>
    {
        private readonly TarotCards activeDeck;

        public StandardTarotDeck(TarotCards cards)
        {
            activeDeck = cards;
            ShuffleTheDeck();
        }

        public List<TarotCards.Card> GetCurrentDeck()
        {
            return activeDeck.Cards;
        }

        public List<TarotCards.Card> DrawCards(int count)
        {
            return activeDeck.Cards.Take(count).ToList();
        }

        public void ShuffleTheDeck()
        {
            activeDeck.Cards = activeDeck.Cards.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
