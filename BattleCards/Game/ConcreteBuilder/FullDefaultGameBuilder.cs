using System;
using System.Collections.Generic;
using BattleCards.Deck;

namespace BattleCards
{
    public class FullDefaultGameBuilder : GameBuilder
    {
        public override void BuildPlayersList()
        {
            _playersList = new List<Player>();

            Console.WriteLine("Chose number of human players:");
            var numberOfHumanPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine("Chose number of AI players:");
            var numberOfAiPlayers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfHumanPlayers; i++)
            {
                _playersList.Add(new Player(new HumanCategorySelector()));
            }
            for (int i = 0; i < numberOfAiPlayers; i++)
            {
                _playersList.Add(new Player(new AiCategorySelector()));
            }

        }

        public override void BuildCardsDeck()
        {
            Console.WriteLine("Chose number of cards:");
            var numberOfCards = int.Parse(Console.ReadLine());
            _deck = new DeckCreator(numberOfCards).Deck;
        }

        public override void BuildCompareCardsRules()
        {
            Console.WriteLine("Only one Compare available");
            base.BuildCompareCardsRules();
            Console.ReadKey();
        }

        public override void BuildDisplay()
        {  
            Console.WriteLine("Only one Display available");
            base.BuildDisplay();
            Console.ReadKey();
            
        }

        public override void BuildNumberOfCardsPerPlayer()
        {
            Console.WriteLine("Only one equal number of cards for player available");
            base.BuildNumberOfCardsPerPlayer();
            Console.ReadKey();
        }
        
    }
}