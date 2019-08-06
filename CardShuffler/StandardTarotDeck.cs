using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler
{
    //DAL
    public class TarotDeck : IDeckInterface
    {
        private readonly TarotCards activeDeck;

        public TarotDeck()
        {
            TarotCards cards = new TarotCards();
            activeDeck = cards;
            ShuffleTheDeck();
        }

        public IActionResult GetCurrentDeck()
        {
            return new JsonResult(JsonConvert.SerializeObject(activeDeck.Cards));
        }

        public IActionResult DrawCards(int count)
        {
            //reformat details a bit
            var response = activeDeck.Cards.Take(count).ToList();
            return new JsonResult(JsonConvert.SerializeObject(response));
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

        public string TranslateCard(object card)
        {
            if (card is null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            throw new NotImplementedException();
        }
    }
}