using System.Collections.Generic;
using BattleCards.Deck;

namespace BattleCards.Interfaces
{
    public interface IDisplay
    {
        public void ShowMenuForChoosingCompareCategory(Card cardToCompare, string activePLayerNick );
        public void ShowAllCardsInRound(List<Player> players, string category);
        public void ShowInformationAboutRoundWinner(Player roundWinner, int numberOfCardsWon);
        public void ShowEndGameMessage(string winnerNick);
        void ShowDrawMessage(List<Player> playersStillInRound);
        void ShowGameStatus(List<Player> playersPlayersList, string activePlayerNick);
        void ShowPlayerHasNotEnoughCardsForDrawRounds(string playerNick);
    }
}