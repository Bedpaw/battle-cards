using System.Collections.Generic;

namespace BattleCards
{
    public class AiVersusAiBuilder : GameBuilder
    {
        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new AiCategorySelector()),
                new Player(new AiCategorySelector())
            };
        }
    }
}