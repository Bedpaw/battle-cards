using System;
using System.Collections.Generic;
using System.Threading;
using BattleCards.Interfaces;

namespace BattleCards.View
{
    public class ConsoleDisplay : IDisplay
    {
        public void ShowMenuForChoosingCompareCategory(Card cardToCompare, string activePLayerNick)
        {   Console.Clear(); 
            Console.WriteLine($"{activePLayerNick} draw {cardToCompare.Name} with stats below:\n");
            
            foreach (var (key, value) in cardToCompare.CardStats)
            {
                Console.WriteLine($"[{key + 1}] {value.Name}: {value.Value}");
            }
            Console.WriteLine("Please choose Category to compare: ");
        }
        public void ShowAllCardsInRound(List<Player> players, string category )
        {    Console.Clear();
            foreach (var player in players)
            {
                var card = player.CardForActualRound;
                var cardCategory = card.GetCategoryById(category); 
                Console.WriteLine($"{player.Nick} shows {card.Name} with {cardCategory.Name} - {cardCategory.Value}");
                Thread.Sleep(1000);
            }
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
            Console.WriteLine($"Congrats {winnerNick}, you have won a game!");
            Console.ReadKey();
        }

        public void ShowDrawMessage(List<Player> playersStillInRound)
        {
            Console.WriteLine("\nIT'S DRAW!");
            Console.WriteLine("STILL IN GAME:");
            foreach (var player in playersStillInRound)
            {
                Console.WriteLine(player.Nick);
                Thread.Sleep(500);
            }
            Thread.Sleep(1000);
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
            Console.WriteLine($"{playerNick} cannot participate in extra round, because he has no enough cards... ");
            Thread.Sleep(1000);
        }
    }
}