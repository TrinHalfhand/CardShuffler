using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult GetCurrentDeck()
        {
            var jsonContent = JsonConvert.SerializeObject(new List<PlayingCards.Card>(PlayingCardDeck.GetCurrentDeck()));
            return new JsonResult(jsonContent);
        }

        [HttpGet]
        public IActionResult DrawCards(int count)
        {
            var jsonContent = JsonConvert.SerializeObject(new List<PlayingCards.Card>(PlayingCardDeck.DrawCards(count)));
            return new JsonResult(jsonContent);
        }
    }
}
