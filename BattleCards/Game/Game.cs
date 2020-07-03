using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            while (Players.OnlyOneAlive() == false)
            {
                Display.ShowGameStatus(Players.PlayersList, Players.ActivePlayer.Nick);
                
                var cardsToCompare = Players.GiveFirstCard();
                var categoryToCompare = ChooseCategoryToCompare(Players.ActivePlayer);
                
                Display.ShowAllCardsInRound(Players.PlayersList, categoryToCompare);
                Compare.CompareCards(categoryToCompare, cardsToCompare);
                
                if (Compare.IsDraw()) StartDrawLoop(categoryToCompare);
                
                UpdateGameAfterRound();
                
            }
            Display.ShowEndGameMessage(Players.ActivePlayer.Nick);
        }

        private void StartDrawLoop(string categoryToCompare)
        {    //TODO handle if 0 or 1 player can go to next round
            do
            {
                var playersStillInRound = GetPlayersStillInRound();
                
                Display.ShowDrawMessage(playersStillInRound.PlayersList);
                
                playersStillInRound.GiveOneCardAsPrize(Compare.CardsFromAllRounds);
                var cardsToCompare = playersStillInRound.GiveFirstCard();
                
                Display.ShowAllCardsInRound(playersStillInRound.PlayersList, categoryToCompare);
                Compare.CompareCards(categoryToCompare, cardsToCompare);
                    
            } while (Compare.IsDraw()); 
        }

        private Players GetPlayersStillInRound(bool withTwoOrMoreCards = true)
        {
            var playersWhichDrawInLastRound = Players.PlayersList
                .FindAll(player => Compare.WinnerCardsFromLastRound
                    .Exists(card => player.CardForActualRound.Equals(card)));
            if (withTwoOrMoreCards)
            {
                return new Players(playersWhichDrawInLastRound.FindAll(player =>
                {
                    if (player.Deck.Count >= 2) return true;

                    Display.ShowPlayerHasNotEnoughCardsForDrawRounds(player.Nick);
                    return false;

                }));
            }
            return new Players(playersWhichDrawInLastRound);
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
            Players.SwapActivePlayer();
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