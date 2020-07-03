using System.Collections.Generic;
using BattleCards.Deck;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class HumanVersusAiBuilder : GameBuilder
    {
        public override void BuildCardsDeck()
        {
            IDeckReader deckReader = new FromCsvFileReader();
            _deck = deckReader.GetListOfCards(
                @"C:\Users\bedpa\RiderProjects\BattleCards\BattleCards\Db\cards.csv"); // :TODO change to relative path
        }
        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new HumanCategorySelector()),
                new Player(new AiCategorySelector())
            };
        }
        
    }
}