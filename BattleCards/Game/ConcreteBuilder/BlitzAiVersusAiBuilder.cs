using System.Collections.Generic;
using BattleCards.View;

namespace BattleCards
{
    public class BlitzAiVersusAiBuilder : GameBuilder
    {
        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new AiCategorySelector()),
                new Player(new AiCategorySelector())
            };
        }

        public override void BuildDisplay()
        {
            _display = new NoDisplay();
        }
    }
}