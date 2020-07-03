using System.Collections.Generic;
namespace BattleCards
{
    public class HumanVersusHumanGameBuilder : GameBuilder
    {
        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new HumanCategorySelector()),
                new Player(new HumanCategorySelector())
            };
        }
    }
}