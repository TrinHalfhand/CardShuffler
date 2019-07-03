using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler
{
    //DAL
    public class TarotDeck : IDeckInterface<PlayingCards.Card>
    {
        public enum Suit
        {
            Cups,
            Pentacles,
            Wands,
            Swords
        }

        private readonly PlayingCards activeDeck;

        public TarotDeck(PlayingCards cards)
        {
            activeDeck = cards;
            ShuffleTheDeck();
        }

        public List<PlayingCards.Card> GetCurrentDeck()
        {
            return activeDeck.Cards;
        }

        public List<PlayingCards.Card> DrawCards(int count)
        {
            return activeDeck.Cards.Take(count).ToList();
        }

        public void ShuffleTheDeck()
        {
            activeDeck.Cards = activeDeck.Cards.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
