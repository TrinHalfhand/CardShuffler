using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CardShuffler.TarotDeck;

namespace CardShuffler
{
    internal interface IDeckInterface
    {
        List<PlayingCards.Card> GetCurrentDeck();
        List<PlayingCards.Card> ReadFirst3Cards();
        void ShuffleTheDeck();
    }
}
