using System.Security.Cryptography;

namespace BattleCards.Deck
{
    public class Category
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Category(string categoryName, int categoryValue)
        {
            Name = categoryName;
            Value = categoryValue;
        }
    }
}