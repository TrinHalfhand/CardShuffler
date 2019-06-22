using CardShuffler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CardTester
{
    [TestClass]
    public class CardTester
    {
        readonly TarotDeck deck = new TarotDeck();

        [TestMethod]
        public void DeckHasRightCount()
        {
            var currentDeck = deck.GetCurrentDeck();
            Assert.AreEqual(currentDeck.Count(), 52);
        }
        public void TarotReadHasRightCount()
        {
            var currentDeck = deck.ReadFirst3Cards();
            Assert.AreEqual(currentDeck.Count(), 3);
        }

        [TestMethod]
        public void ShuffleDeckAgain()
        {
            var currentCards = deck.ReadFirst3Cards();
            //shuffle deck
            deck.ShuffleTheDeck();
            var nextCards = deck.ReadFirst3Cards();

            Assert.AreNotEqual(nextCards[0].CardRank + nextCards[0].CardSuit, currentCards[0].CardRank + currentCards[0].CardSuit);
            Assert.AreNotEqual(nextCards[1].CardRank + nextCards[1].CardSuit, currentCards[1].CardRank + currentCards[1].CardSuit);
            Assert.AreNotEqual(nextCards[2].CardRank + nextCards[2].CardSuit, currentCards[2].CardRank + currentCards[2].CardSuit);
        }

        [TestMethod]
        public void ReadFirstCard_MustHaveContent()
        {
            var currentCards = deck.ReadFirst3Cards();
            string message = Psychic.TranslateCard(currentCards[0]);
            Assert.IsNotNull(message);
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest1()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Hearts, "1");
            var messages = Psychic.TranslateCard(card);
            Assert.AreEqual(messages, "Ace of Cups: New love or closer relationship");
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest2()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Clubs, "1");
            var messages = Psychic.TranslateCard(card);
            Assert.AreEqual(messages, "Ace of Wands: New Inspiration and Mental Energy");
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest3()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Spades, "J");
            var messages = Psychic.TranslateCard(card);
            Assert.AreEqual(messages, "Knave of Swords: Someone on a mission");
        }
    }
}
