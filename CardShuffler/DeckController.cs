using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardShuffler
{
    [Route("[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IDeckInterface PlayingCardDeck;

        public DeckController(IDeckInterface cardDeck)
        {
            PlayingCardDeck = cardDeck;
        }

        [HttpPost("ShuffleTheDeck")]
        public void ShuffleTheDeck(int uniqueCardCount = 0)
        {
            PlayingCardDeck.ShuffleTheDeck(uniqueCardCount);
        }

        [HttpGet("CurrentDeck")]
        public IActionResult GetCurrentDeck()
        {
            string jsonContent = JsonConvert.SerializeObject(PlayingCardDeck.GetCurrentDeck());
            return new JsonResult(jsonContent);
        }



        [HttpGet]
        public IActionResult DrawCards(int count)
        {
            var jsonContent = JsonConvert.SerializeObject(PlayingCardDeck.DrawCards(count));
            return new JsonResult(jsonContent);
        }
    }
}
