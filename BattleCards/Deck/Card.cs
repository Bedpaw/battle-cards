using System.Security.Cryptography;

namespace BattleCards
{
    public class Card
    {
        public string Name { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        
        
        public Card(
            string name,
            string category1,
            string category2,
            string category3,
            string category4
        )
        {
            Name = name;
            Category1 = category1;
            Category2 = category2;
            Category3 = category3;
            Category4 = category4;

        }
    }
}