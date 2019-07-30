using System.Collections.Generic;

namespace CardShuffler
{
    public interface IDeckInterface<T>
    {
        List<T> GetCurrentDeck();
        List<T> DrawCards(int count);
        void ShuffleTheDeck(int uniqueCardCount);
    }
}
