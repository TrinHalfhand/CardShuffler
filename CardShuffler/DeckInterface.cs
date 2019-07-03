using System.Collections.Generic;

namespace CardShuffler
{
    internal interface IDeckInterface<T>
    {
        List<T> GetCurrentDeck();
        List<T> DrawCards(int count);
        void ShuffleTheDeck();
    }
}
