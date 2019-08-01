using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CardShuffler
{
    public interface IDeckInterface
    {
        IActionResult GetCurrentDeck();
        IActionResult DrawCards(int count);
        void ShuffleTheDeck(int uniqueCardCount);
        string TranslateCard(Object card);
    }
}
