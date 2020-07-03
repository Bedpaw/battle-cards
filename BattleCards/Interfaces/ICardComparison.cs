using System;
using System.Collections.Generic;

namespace BattleCards.Interfaces
{
    public interface ICardComparison
    {
        public List<Card> CardsFromAllRounds { get; set; }
        public List<Card> WinnerCardsFromLastRound { get; set; }
        
        public void CompareCards(string categoryToCompare, List<Card> cardsToCompare);
        public bool IsDraw();
        void ClearLastCompare();
    }
}