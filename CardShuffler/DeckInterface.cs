using System.Collections;
using System.Collections.Generic;

namespace CardShuffler
{
    public interface IDeckInterface
    {
        ICollection GetCurrentDeck();
        ICollection DrawCards(int count);
        void ShuffleTheDeck(int uniqueCardCount);
    }
}
