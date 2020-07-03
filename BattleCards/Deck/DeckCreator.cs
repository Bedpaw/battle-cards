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

            for (var i = 0; i < numberOfCards; i++)
            {
                var cardStats = new Dictionary<int, Category>
                {
                    {0, new Category(CategoryNames[0], rnd.Next(0, 3))},
                    {1, new Category(CategoryNames[1], rnd.Next(0, 3))},
                    {2, new Category(CategoryNames[2], rnd.Next(0, 3))},
                    {3, new Category(CategoryNames[3], rnd.Next(0, 3))},
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