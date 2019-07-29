using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardShuffler
{
    [Route("api/[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckInterface<PlayingCards.Card> PlayingCardDeck;

        public DeckController(IDeckInterface<PlayingCards.Card> playingCardDeck)
        {
            PlayingCardDeck = playingCardDeck;
        }

        [HttpPost("ShuffleTheDeck")]
        public void ShuffleTheDeck()
        {
            PlayingCardDeck.ShuffleTheDeck();
        }

        [HttpGet]
        public List<PlayingCards.Card> GetCurrentDeck()
        {
            return PlayingCardDeck.GetCurrentDeck();
        }

        [HttpGet]
        public List<PlayingCards.Card> DrawCards(int count)
        {
            return PlayingCardDeck.DrawCards(count);
        }
    }
}
