using System;
using System.Collections.Generic;
using BattleCards.Deck;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class GameCreator
    {
        public static Game CreateNewGame()
        {
            IDeckReader deckReader = new FromCsvFileReader();
            var deck = deckReader.GetListOfCards(@"C:\Users\bedpa\RiderProjects\BattleCards\BattleCards\Db\cards.csv"); // :TODO change to relative path
            
            var playersList = new List<Player>
            {
                new Player(new HumanCategorySelector()),
                new Player(new AiCategorySelector())
            };

            var cardsPerPlayer = deck.Count / playersList.Count;

            var compareRules = new IsCategoryValueTheBiggest();
           
            return new Game(
                deck,
                playersList,
                cardsPerPlayer,
                compareRules
            );
            
        }
    }
}