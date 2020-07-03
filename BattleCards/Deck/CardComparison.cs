using System.Collections.Generic;
using System.Linq;
using BattleCards.Interfaces;

namespace BattleCards.Deck
{
    public class IsCategoryValueTheBiggest : ICardComparison
    {
        public List<Card> CardsFromAllRounds { get; set; } = new List<Card>();
        public List<Card> WinnerCardsFromLastRound { get; set;}
        
        public void CompareCards(string categoryToCompare, List<Card> cardsToCompare)
        {
            /*
             * If it's draw, return list of all winners Cards, else return List with 1 winnerCard
             */

            var winnerCards = new List<Card> { cardsToCompare[0] };
            
            foreach (var card in cardsToCompare)
            {
                var winnerValue = winnerCards[0].GetCategoryById(categoryToCompare).Value;
                var currentValue = card.GetCategoryById(categoryToCompare).Value;

                if (currentValue > winnerValue) winnerCards = new List<Card> { card };

                else if (winnerValue == currentValue) winnerCards.Add(card);
            }

            CardsFromAllRounds.AddRange(winnerCards);
            WinnerCardsFromLastRound = winnerCards;
        }
        
        public bool IsDraw() => WinnerCardsFromLastRound.Count != 1;
        public void ClearLastCompare()
        {
            CardsFromAllRounds = new List<Card>();
            WinnerCardsFromLastRound = new List<Card>();
        }
    }
}