using CardShuffler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CardTester
{
    [TestClass]
    public class CardTester
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
            Assert.AreNotEqual(nextCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString(), currentCards[1].CardRank.ToString() + nextCards[1].CardSuit.ToString()); Assert.AreNotEqual(nextCards[2].CardRank, currentCards[2].CardRank);
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
            Assert.AreEqual(messages, "Ace of Cups: New love or closer relationship");
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest2()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Clubs, PlayingCards.Rank.Ace);
            var messages = Psychic.TranslateCard(card);
            Assert.AreEqual(messages, "Ace of Wands: New Inspiration and Mental Energy");
        }

        [TestMethod]
        public void ReadFirstCard_SuitTest3()
        {
            PlayingCards.Card card = new PlayingCards.Card(PlayingCards.Suit.Spades, PlayingCards.Rank.Jack);
            var messages = Psychic.TranslateCard(card);
            Assert.AreEqual(messages, "Knave of Swords: Someone on a mission");
        }
    }
}
