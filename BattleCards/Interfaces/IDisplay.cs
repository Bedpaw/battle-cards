using System.Collections.Generic;
using BattleCards.Deck;

namespace BattleCards.Interfaces
{
    public interface IDisplay
    {
        public void ShowMenuForChoosingCompareCategory(Card cardToCompare, string activePLayerNick );
        public void ShowAllCardsInRound(List<Player> players, string category);
        public void ShowInformationAboutRoundWinner(Player roundWinner);
        
    }
}