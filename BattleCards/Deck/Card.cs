using System.Collections.Generic;
using System.Security.Cryptography;
using BattleCards.Deck;

namespace BattleCards
{
    public class Card
    {
        public string Name { get; set; }

        internal enum Categories { First = 0, Second = 1, Third = 2, Fourth = 3 }
        public Dictionary<int, Category> CardStats { get; set; } 

        public Card(string name, Dictionary<int, Category> cardStats)
        {
            Name = name;
            CardStats = cardStats;
        }
    }
}