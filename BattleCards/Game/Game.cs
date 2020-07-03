using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class Game
    {
        private Players Players { get; set; }
        private ICardComparison Compare { get; set; }
        private IDisplay Display { get; set; }
        public Game(List<Card> cardsDeck, List<Player> listOfPlayers, int numberOfCardsForEachPlayer,
            ICardComparison compareRules, IDisplay display)
        {
            Players = new Players(listOfPlayers);
            DealCardsForPlayers(numberOfCardsForEachPlayer, cardsDeck);
            Compare = compareRules;
            Display = display;
        }
        
        public void GameLogic()
        {
            while (true)
            {
                var cardsToCompare = Players.GiveFirstCard();
                var categoryToCompare = ChooseCategoryToCompare(Players.ActivePlayer);
                
                Display.ShowAllCardsInRound(Players.PlayersList, categoryToCompare);
                Compare.CompareCards(categoryToCompare, cardsToCompare);
                
                if (Compare.IsDraw()) StartDrawLoop(categoryToCompare);
                
                UpdateGameAfterRound();
                
                if (Players.OnlyOneAlive()) break;
                Players.SwapActivePlayer();
            }
            Display.ShowEndGameMessage(Players.PlayersList[0].Nick);
        }

        private void StartDrawLoop(string categoryToCompare)
        { 
            do
            {
                var playersStillInRound = new Players(Players.PlayersList
                    .FindAll(player => Compare.WinnerCardsFromLastRound
                    .Exists(card => player.CardForActualRound.Equals(card))));

                var cardsToCompare = playersStillInRound.GiveFirstCard();
                    
                Display.ShowAllCardsInRound(playersStillInRound.PlayersList, categoryToCompare);
                Compare.CompareCards(categoryToCompare, cardsToCompare);
                    
            } while (Compare.IsDraw()); 
        }

        private string ChooseCategoryToCompare(Player aPlayer)
        {
            Display.ShowMenuForChoosingCompareCategory(aPlayer.CardForActualRound, aPlayer.Nick);
            return aPlayer.CategorySelector.SelectCategory(aPlayer.CardForActualRound);
        }

        private void UpdateGameAfterRound()
        {
            var winner = Players.GetCardOwner(Compare.WinnerCardsFromLastRound[0]);
            winner.TakeAllCards(Compare.CardsFromAllRounds);
            Compare.ClearLastCompare();

            Display.ShowInformationAboutRoundWinner(winner);
            Players.RemovePlayersWithoutCards();

        }
        private void DealCardsForPlayers(int numberOfCardsForEachPlayer, List<Card> cardsDeck)
        {
            foreach (var card in cardsDeck)
            {
                Players.ActivePlayer.Deck.Enqueue(card);
                Players.SwapActivePlayer();
            }
        }
    }
}