using System;
using System.Collections;
using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class Game
    {
        private Players Players { get; set; }
        private ICardComparison Compare { get; set; }
        public Game(
            IEnumerable cardsDeck,
            List<Player> listOfPlayers,
            int numberOfCardsForEachPlayer,
            ICardComparison compareRules
            )
        {
            Players = new Players(listOfPlayers);
            DealCardsForPlayers(numberOfCardsForEachPlayer, cardsDeck);
            Compare = compareRules;
        }
        
        public void GameLogic()
        {
            while (true)
            {
                var cardsToCompare = Players.GiveFirstCard();
                var categoryToCompare = Players.ActivePlayer.CategorySelector.SelectCategory();
                
                Compare.CompareCards(categoryToCompare, cardsToCompare, Players.PlayersList);
                var playerWhoWinRound = Compare.GetWinner();
                
                playerWhoWinRound.TakeAllCards(cardsToCompare);

                Players.RemovePlayersWithoutCards();
                if (Players.PlayersList.Count == 1) break;

                Players.SwapActivePlayer();
            }
            DisplayEndGameResults();
        }

        private void DisplayEndGameResults()
        {
            throw new NotImplementedException();
        }
        
        private void DealCardsForPlayers(int numberOfCardsForEachPlayer,  IEnumerable cardsDeck)
        {
            throw new NotImplementedException();
        }
    }
}