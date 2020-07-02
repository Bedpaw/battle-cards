﻿using System.Collections.Generic;
using BattleCards.Deck;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class HumanVersusHumanGameBuilder : GameBuilder
    {   
        // :TODO refactor  
        private List<Card> _deck;
        private List<Player> _playersList;
        private int _cardsPerPlayer;
        private ICardComparison _cardCompare;
        
            public override void BuildCardsDeck()
        {
            _deck = new DeckCreator(120).Deck;
        }

        public override void BuildPlayersList()
        {
            _playersList = new List<Player>
            {
                new Player(new HumanCategorySelector()),
                new Player(new HumanCategorySelector())
            };
        }

        public override void BuildNumberOfCardsPerPlayer()
        {
            _cardsPerPlayer = _deck.Count / _playersList.Count;
        }

        public override void BuildCompareCardsRules()
        {
            _cardCompare = new IsCategoryValueTheBiggest();
        }

        public override Game GetResult()
        {
            return new Game(
                _deck,
                _playersList,
                _cardsPerPlayer,
                _cardCompare
                );
        }
    }
}