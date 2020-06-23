using System.Collections.Generic;

namespace BattleCards.Interfaces
{
    public interface ICardComparison
    {
        public void CompareCards(string categoryToCompare, List<Card> cardsToCompare, List<Player> listOfPlayers);
        
        public Player GetWinner();
    }
}