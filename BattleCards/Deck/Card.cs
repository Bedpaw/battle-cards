using System.Collections.Generic;
using System.Security.Cryptography;
using BattleCards.Deck;

namespace BattleCards
{
    public class Card
    {
        public string Name { get; set; }
        public Dictionary<int, Category> CardStats { get; set; } 

        public Card(string name, Dictionary<int, Category> cardStats)
        {
            Name = name;
            CardStats = cardStats;
        }

        public Category GetCategoryById(string id) => CardStats[int.Parse(id)];
        
    }
}