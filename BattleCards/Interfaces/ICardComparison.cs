using System;
using System.Collections.Generic;

namespace BattleCards.Interfaces
{
    public interface ICardComparison
    {
        public Card CompareCards(string categoryToCompare, List<Card> cardsToCompare);
    }
}