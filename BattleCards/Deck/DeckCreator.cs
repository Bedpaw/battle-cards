using System;
using System.Collections.Generic;

namespace BattleCards.Deck
{
    public class DeckCreator
    {
        public List<Card> Deck { get; set; }

        public DeckCreator(int numberOfCards)
        {
            var rnd = new Random();
            var deck = new List<Card>();
            int valueBorders() => new Random().Next(1, 5);

            for (var i = 0; i < numberOfCards; i++)
            {
                var cardStats = new Dictionary<int, Category>
                {
                    {0, new Category(CategoryNames[0], valueBorders())},
                    {1, new Category(CategoryNames[1], valueBorders())},
                    {2, new Category(CategoryNames[2], valueBorders())},
                    {3, new Category(CategoryNames[3], valueBorders())},
                };
                
                var newCard = new Card(CardNames[rnd.Next(0, 13)], cardStats);
                deck.Add(newCard);
            }

            Deck = deck;
        }
        private Dictionary<int, string> CardNames { get; set; } = new Dictionary<int, string>
        {
            {0, "Troglodyte"},
            {1, "Infernal Troglodyte"}, 
            {2, "Harpy" },
            {3, "Harpy Hag"},
            {4, "Beholder"},
            {5, "Evil Eye"}, 
            {6, "Medusa"}, 
            {7, "Medusa Queen"}, 
            {8, "Minotaur"}, 
            {9, "Minotaur King"}, 
            {10, "Manticore"}, 
            {11, "Scorpicore"}, 
            {12, "Red Dragon"},
            {13, "Black Dragon"},
        };
        private Dictionary<int, string> CategoryNames { get; set; } = new Dictionary<int, string>
        {
            {0, "Power"},
            {1, "Defense"},
            {2, "Health"},
            {3, "Agility"},
        };
    }
}