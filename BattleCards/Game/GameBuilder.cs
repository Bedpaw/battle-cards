using System.Collections.Generic;
using BattleCards.Deck;
using BattleCards.Interfaces;
using BattleCards.View;

namespace BattleCards
{
    public abstract class GameBuilder
    
    {
        protected List<Card> _deck;
        protected List<Player> _playersList;
        protected int _cardsPerPlayer;
        protected ICardComparison _cardCompare;
        protected IDisplay _display;

        public virtual void BuildCardsDeck()
        {
            _deck = new DeckCreator(40).Deck;
        }
        public abstract void BuildPlayersList();

        public virtual void  BuildNumberOfCardsPerPlayer()
        {
            _cardsPerPlayer = _deck.Count / _playersList.Count;
        }

        public virtual void BuildCompareCardsRules()
        {
            _cardCompare = new IsCategoryValueTheBiggest();
        }

        public virtual void BuildDisplay()
        {
            _display = new ConsoleDisplay();
        }

        public Game GetResult()
        {
            return new Game(
                _deck,
                _playersList,
                _cardsPerPlayer,
                _cardCompare,
                _display
            );
        }
    }
}