using CardShuffler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CardTester
{
    [TestClass]
    public class TarotCardTester
    {
        readonly DeckController deck;

        public TarotCardTester()
        {
            TarotCards playingCards = new TarotCards();
            StandardTarotDeck playingCardService = new StandardTarotDeck(playingCards);
            deck = new DeckController(playingCardService);
        }

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeckResult = deck.GetCurrentDeck();

            Assert.IsTrue(currentDeckResult is JsonResult);
            var currentText = (currentDeckResult as JsonResult).Value.ToString();
            var currentDeck = JsonConvert.DeserializeObject<List<Deck.Card>>(currentText);
            Assert.AreEqual(currentDeck.Count(), 56);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeckResult = deck.DrawCards(3);

            Assert.IsTrue(currentDeckResult is JsonResult);

            string current = (currentDeckResult as JsonResult).Value.ToString();
            List<Deck.Card> currentDeck = JsonConvert.DeserializeObject<List<Deck.Card>>(current);
            Assert.AreEqual(currentDeck.Count(), 3);
        }

        [TestMethod]
        public void ShuffleDeckAgain()
        {
            var currentCardsResult = deck.DrawCards(3);
            deck.ShuffleTheDeck(3);
            var nextCardsResult = deck.DrawCards(3);

            //Read Json Results
            Assert.IsTrue(currentCardsResult is JsonResult);
            string currentCardSet = (currentCardsResult as JsonResult).Value.ToString();
            Assert.IsTrue(nextCardsResult is JsonResult);
            string nextCardSet = (nextCardsResult as JsonResult).Value.ToString();

            List<Deck.Card> nextCards = JsonConvert.DeserializeObject<List<Deck.Card>>(nextCardSet);
            List<Deck.Card> currentCards = JsonConvert.DeserializeObject<List<Deck.Card>>(currentCardSet);

            Assert.AreNotEqual(nextCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString(), currentCards[0].CardRank.ToString() + currentCards[0].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString(), currentCards[1].CardRank.ToString() + currentCards[1].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString(), currentCards[2].CardRank.ToString() + currentCards[2].CardSuit.ToString());
        }

        [TestMethod]
        public void ReadFirstCard_MustHaveContent()
        {
            var currentDeckResult = deck.DrawCards(3);

            Assert.IsTrue(currentDeckResult is JsonResult);

            string current = (currentDeckResult as JsonResult).Value.ToString();
            List<Deck.Card> currentCards = JsonConvert.DeserializeObject<List<Deck.Card>>(current);

            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [DataRow("Ace of Cups", Deck.Suit.Hearts, Deck.Rank.Ace)]
        [DataRow("Ace of Wands", Deck.Suit.Clubs, Deck.Rank.Ace)]
        [DataRow("Knave of Swords", Deck.Suit.Spades, Deck.Rank.Jack)]
        [DataTestMethod]
        public void ReadFirstCard_SuitTest(string result, Deck.Suit cardSuite, Deck.Rank cardRank)
        {
            Deck.Card card = new Deck.Card(cardSuite, cardRank);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains(result));
        }
    }
    [TestClass]
    public class PlayingCardTester
    {
        readonly PlayingCardTarotDeck deck = new PlayingCardTarotDeck(new Deck());

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeck = deck.GetCurrentDeck();
            Assert.AreEqual(currentDeck.Count, 52);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeck = deck.DrawCards(3);
            Assert.AreEqual(currentDeck.Count, 3);
        }

        [TestMethod]
        public void ShuffleDeckAgain()
        {
            var currentCards = deck.DrawCards(3).OfType<Deck.Card>().ToList(); 
            //shuffle deck
            deck.ShuffleTheDeck(3);
            var nextCards = deck.DrawCards(3).OfType<Deck.Card>().ToList(); 

            Assert.AreNotEqual(nextCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString(), currentCards[0].CardRank.ToString() + currentCards[0].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString(), currentCards[1].CardRank.ToString() + currentCards[1].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString(), currentCards[2].CardRank.ToString() + currentCards[2].CardSuit.ToString());
        }

        [TestMethod]
        public void ReadFirstCard_MustHaveContent()
        {
            var currentCards = deck.DrawCards(3).OfType<Deck.Card>().ToList();
            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [DataRow("Ace of Cups", Deck.Suit.Hearts, Deck.Rank.Ace)]
        [DataRow("Ace of Wands", Deck.Suit.Clubs, Deck.Rank.Ace)]
        [DataRow("Knave of Swords", Deck.Suit.Spades, Deck.Rank.Jack)]
        [DataTestMethod]
        public void ReadFirstCard_SuitTest(string result, Deck.Suit cardSuit, Deck.Rank cardRank)
        {
            Deck.Card card = new Deck.Card(cardSuit, cardRank);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains(result));
        }
    }
}
