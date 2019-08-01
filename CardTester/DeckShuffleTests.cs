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
            TarotDeck playingCardService = new TarotDeck(playingCards);
            deck = new DeckController(playingCardService);
        }

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeckResult = deck.GetCurrentDeck();

            Assert.IsTrue(currentDeckResult is JsonResult);
            string currentText = (currentDeckResult as JsonResult).Value.ToString();
            List<TarotCards.Card> currentDeck = JsonConvert.DeserializeObject<List<TarotCards.Card>>(currentText);
            Assert.AreEqual(currentDeck.Count(), 56);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeckResult = deck.DrawCards(3);

            Assert.IsTrue(currentDeckResult is JsonResult);

            string current = (currentDeckResult as JsonResult).Value.ToString();
            List<TarotCards.Card> currentDeck = JsonConvert.DeserializeObject<List<TarotCards.Card>>(current);
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

            List<TarotCards.Card> nextCards = JsonConvert.DeserializeObject<List<TarotCards.Card>>(nextCardSet);
            List<TarotCards.Card> currentCards = JsonConvert.DeserializeObject<List<TarotCards.Card>>(currentCardSet);

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
            List<TarotCards.Card> currentCards = JsonConvert.DeserializeObject<List<TarotCards.Card>>(current);

            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [DataRow("Ace of Cups", TarotCards.Suit.Cups, 1)]
        [DataRow("Ace of Wands", TarotCards.Suit.Wands, 1)]
        [DataRow("Knave of Swords", TarotCards.Suit.Swords, 11)]
        [DataTestMethod]
        public void ReadFirstCard_SuitTest(string result, TarotCards.Suit cardSuite, int cardRank)
        {
            TarotCards.Card card = new TarotCards.Card(cardSuite, cardRank);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains(result));
        }
    }
    [TestClass]
    public class PlayingCardTester
    {
        readonly PlayingCardTarotDeck deck = new PlayingCardTarotDeck(new PlayingCards());

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeckResult = deck.GetCurrentDeck();
            Assert.IsTrue(currentDeckResult is JsonResult);
            var currentText = (currentDeckResult as JsonResult).Value.ToString();
            var currentDeck = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(currentText);
            Assert.AreEqual(currentDeck.Count, 52);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeckResult = deck.DrawCards(3);

            Assert.IsTrue(currentDeckResult is JsonResult);

            string current = (currentDeckResult as JsonResult).Value.ToString();
            List<PlayingCards.Card> currentDeck = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(current);
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

            List<PlayingCards.Card> nextCards = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(nextCardSet);
            List<PlayingCards.Card> currentCards = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(currentCardSet);

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
            List<PlayingCards.Card> currentCards = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(current);

            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [DataRow("Ace of Cups", PlayingCards.Suit.Hearts, PlayingCards.Rank.Ace)]
        [DataRow("Ace of Wands", PlayingCards.Suit.Clubs, PlayingCards.Rank.Ace)]
        [DataRow("Knave of Swords", PlayingCards.Suit.Spades, PlayingCards.Rank.Jack)]
        [DataTestMethod]
        public void ReadFirstCard_SuitTest(string result, PlayingCards.Suit cardSuit, PlayingCards.Rank cardRank)
        {
            PlayingCards.Card card = new PlayingCards.Card(cardSuit, cardRank);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains(result));
        }
    }
}
