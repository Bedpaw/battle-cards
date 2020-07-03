using System.Collections.Generic;

namespace BattleCards
{
    public class TwoHumanTwoAiBuilder : GameBuilder
    {

        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new HumanCategorySelector()),
                new Player(new HumanCategorySelector()),
                new Player(new AiCategorySelector()),
                new Player(new AiCategorySelector())
            };
        }
    }
}