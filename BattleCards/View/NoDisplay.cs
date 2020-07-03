using System;
using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards.View
{
    public class NoDisplay : IDisplay
    {
        public void ShowMenuForChoosingCompareCategory(Card cardToCompare, string activePLayerNick)
        {
        }

        public void ShowAllCardsInRound(List<Player> players, string category)
        {
        }

        public void ShowInformationAboutRoundWinner(Player roundWinner, int numberOfCardsWon)
        {
            Console.WriteLine($"\n{roundWinner.Nick} has won this round and took {numberOfCardsWon} cards!");
            Console.WriteLine("Press any button for next round");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowEndGameMessage(string winnerNick)
        {
        }

        public void ShowDrawMessage(List<Player> playersStillInRound)
        {
        }

        public void ShowGameStatus(List<Player> playersPlayersList, string activePlayerNick)
        {
            Console.Clear(); 
            foreach (var player in playersPlayersList)
            {
                Console.WriteLine($"{player.Nick} has {player.Deck.Count} cards");
            }
            Console.WriteLine($"\nTime for {activePlayerNick}");
            Console.WriteLine("Press any key to start round");
            Console.ReadKey();
        }

        public void ShowPlayerHasNotEnoughCardsForDrawRounds(string playerNick)
        {
        }
    }
}