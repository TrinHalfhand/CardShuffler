using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler
{
    //DAL
    public class PlayingCardTarotDeck : IDeckInterface<PlayingCards.Card>
    {
        private readonly PlayingCards activeDeck;

        public PlayingCardTarotDeck(PlayingCards cards)
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
