using System.Collections.Generic;
using System.Linq;
using BattleCards.Interfaces;

namespace BattleCards.Deck
{
    public class IsCategoryValueTheBiggest : ICardComparison
    { 
        public Card CompareCards(string categoryToCompare, List<Card> cardsToCompare)
        {
            var categoryIndex = int.Parse(categoryToCompare);
            var winnerCard = cardsToCompare[0];
            
            foreach (var card in cardsToCompare.Where(card => card.CardStats[categoryIndex].Value > winnerCard.CardStats[categoryIndex].Value))
            {
                winnerCard = card;
            }

            return winnerCard;

        }
        
    }
}