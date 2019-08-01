using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardShuffler
{
    [Route("[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IDeckInterface cardDeck;

        public DeckController(IDeckInterface cardDeck)
        {
            this.cardDeck = cardDeck;
        }

        [HttpPost("ShuffleTheDeck")]
        public void ShuffleTheDeck(int uniqueCardCount = 0)
        {
            cardDeck.ShuffleTheDeck(uniqueCardCount);
        }

        [HttpGet("CurrentDeck")]
        [ProducesResponseType(typeof(PlayingCards.Card), StatusCodes.Status200OK)]
        public IActionResult GetCurrentDeck()
        {
            return cardDeck.GetCurrentDeck();
        }

        [HttpGet]
        [ProducesResponseType(typeof(PlayingCards.Card), StatusCodes.Status200OK)]
        public IActionResult DrawCards(int count)
        {
            var jsonContent = JsonConvert.SerializeObject(cardDeck.DrawCards(count));
            return new JsonResult(jsonContent);
        }
    }
}
