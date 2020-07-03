﻿using System.Collections.Generic;
using BattleCards.Deck;
using BattleCards.Interfaces;
using BattleCards.View;

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