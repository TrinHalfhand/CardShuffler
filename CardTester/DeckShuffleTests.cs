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
            PlayingCards playingCards = new PlayingCards();
            PlayingCardTarotDeck playingCardService = new PlayingCardTarotDeck(playingCards);
            deck = new DeckController(playingCardService);
        }

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeckResult = deck.GetCurrentDeck();

            Assert.IsTrue(currentDeckResult is JsonResult);
            var currentText = (currentDeckResult as JsonResult).Value.ToString();
            var currentDeck = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(currentText);
            Assert.AreEqual(currentDeck.Count(), 52);
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
            deck.ShuffleTheDeck();
            var nextCardsResult = deck.DrawCards(3);

            //Read Json Results
            Assert.IsTrue(currentCardsResult is JsonResult);
            string currentCardSet = (currentCardsResult as JsonResult).Value.ToString();
            Assert.IsTrue(nextCardsResult is JsonResult);
            string nextCardSet = (nextCardsResult as JsonResult).Value.ToString();

            List<PlayingCards.Card> nextCards = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(nextCardSet);
            List<PlayingCards.Card> currentCards = JsonConvert.DeserializeObject<List<PlayingCards.Card>>(currentCardSet);

            Assert.AreNotEqual(nextCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString(), currentCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString(), currentCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString(), currentCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString());
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

        [TestMethod]
        public void ReadFirstCard_SuitTest1()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Hearts, PlayingCards.Rank.Ace);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Ace of Cups"));
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest2()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Clubs, PlayingCards.Rank.Ace);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Ace of Wands"));
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest3()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Spades, PlayingCards.Rank.Jack);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Knave of Swords"));
        }
    }
    [TestClass]
    public class PlayingCardTester
    {
        readonly PlayingCardTarotDeck deck = new PlayingCardTarotDeck(new PlayingCards());

        [TestMethod]

        public void DeckHasRightCount()
        {
            var currentDeck = deck.GetCurrentDeck();
            Assert.AreEqual(currentDeck.Count(), 52);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeck = deck.DrawCards(3);
            Assert.AreEqual(currentDeck.Count(), 3);
        }

        [TestMethod]
        public void ShuffleDeckAgain()
        {
            var currentCards = deck.DrawCards(3);
            //shuffle deck
            deck.ShuffleTheDeck();
            var nextCards = deck.DrawCards(3);

            Assert.AreNotEqual(nextCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString(), currentCards[0].CardRank.ToString() + nextCards[0].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString(), currentCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString());
            Assert.AreNotEqual(nextCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString(), currentCards[2].CardRank.ToString() + nextCards[2].CardSuit.ToString());
        }

        [TestMethod]
        public void ReadFirstCard_MustHaveContent()
        {
            var currentCards = deck.DrawCards(3);
            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [TestMethod]

        public void ReadFirstCard_SuitTest1()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Hearts, PlayingCards.Rank.Ace);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Ace of Cups"));
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest2()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Clubs, PlayingCards.Rank.Ace);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Ace of Wands"));
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest3()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Spades, PlayingCards.Rank.Jack);
            var messages = Psychic.TranslateCard(card);
            Assert.IsTrue(messages.Contains("Knave of Swords"));
        }
    }
}
