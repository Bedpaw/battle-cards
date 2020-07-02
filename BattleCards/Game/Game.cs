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
                
                Display.ShowMenuForChoosingCompareCategory(Players.ActivePlayer.CardForActualRound, Players.ActivePlayer.Nick);
                
                var categoryToCompare = Players.ActivePlayer.CategorySelector.SelectCategory(Players.ActivePlayer.CardForActualRound);
             
                Display.ShowAllCardsInRound(Players.PlayersList, categoryToCompare);
                
                var winnerCard = Compare.CompareCards(categoryToCompare, cardsToCompare);
                var playerWhoWinRound = Players.GetCardOwner(winnerCard);
                playerWhoWinRound.TakeAllCards(cardsToCompare);

                Display.ShowInformationAboutRoundWinner(playerWhoWinRound);
                

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

        private void DealCardsForPlayers(int numberOfCardsForEachPlayer,  List<Card> cardsDeck)
        {    // Refactor to test only
            var i = 2;
            foreach (var card in cardsDeck)
            {
                if (i % 2 == 0)
                {
                    Players.PlayersList[0].Deck.Enqueue(card);
                }
                else
                {
                    Players.PlayersList[1].Deck.Enqueue(card);
                }
                i++;
            }
        }
    }
}