using System;
using System.Collections.Generic;
using System.Threading;
using BattleCards.Interfaces;

namespace BattleCards.View
{
    public class ConsoleDisplay : IDisplay
    {
        public void ShowMenuForChoosingCompareCategory(Card cardToCompare, string activePLayerNick)
        {
            Console.WriteLine($"{activePLayerNick} draw {cardToCompare.Name} with stats below:\n");
            
            foreach (var (key, value) in cardToCompare.CardStats)
            {
                Console.WriteLine($"{value.Name}: {value.Value}");
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
                Thread.Sleep(1);
            }
        }
        public void ShowInformationAboutRoundWinner(Player roundWinner)
        {    
            Console.WriteLine($"{roundWinner.Nick} has won this round!");
            Console.WriteLine("Press any button for next round");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowEndGameMessage(string winnerNick)
        {
            Console.WriteLine($"Congrats {winnerNick}, you have won a game!");
        }
    }
}