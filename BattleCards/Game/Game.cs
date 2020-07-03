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
                Display.ShowGameStatus(Players.PlayersList, Players.ActivePlayer.Nick); 
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
                var playersStillInRound = GetPlayersStillInRound();
                Display.ShowDrawMessage(playersStillInRound.PlayersList);
                var cardsToCompare = playersStillInRound.GiveFirstCard();
                    
                Display.ShowAllCardsInRound(playersStillInRound.PlayersList, categoryToCompare);
                Compare.CompareCards(categoryToCompare, cardsToCompare);
                    
            } while (Compare.IsDraw()); 
        }

        private Players GetPlayersStillInRound()
        {
            var playersWhichDrawInLastRound = Players.PlayersList
                .FindAll(player => Compare.WinnerCardsFromLastRound
                    .Exists(card => player.CardForActualRound.Equals(card)));

            return new Players(playersWhichDrawInLastRound.FindAll(player =>
            {
                if (player.Deck.Count >= 2) return true;
                
                Display.ShowPlayerHasNotEnoughCardsForDrawRounds(player.Nick);
                return false;

            }));
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

            Display.ShowInformationAboutRoundWinner(winner, Compare.CardsFromAllRounds.Count);
            Compare.ClearLastCompare();
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