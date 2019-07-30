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

        public void ShuffleTheDeck(int uniqueCardCount = 0)
        {
            //review starting deck and make sure top picks are truly different
            var originalDeck = activeDeck.Cards.Take(uniqueCardCount).ToList();

            do
            {
                activeDeck.Cards = activeDeck.Cards.OrderBy(a => Guid.NewGuid()).ToList();
            } while (originalDeck.Where(s => activeDeck.Cards.Take(uniqueCardCount).Any(l => l.CardSuit == s.CardSuit && s.CardRank == l.CardRank)).ToList().Count > 0);
        }
    }
}
