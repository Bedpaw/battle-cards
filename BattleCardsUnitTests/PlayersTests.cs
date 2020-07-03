using System.Collections.Generic;
using BattleCards;
using BattleCards.Deck;
using NUnit.Framework;

namespace BattleCardsUnitTests
{
    public class PlayersTests
    {
        private Player _playerWithOneCard;
        private Player _playerWithThreeCards;
        private Player _playerWithNoCards;
        private Player _playerAiWithOneCard;
        private DeckCreator _deckCreator = new DeckCreator(5);
        
        [SetUp]
        public void Setup()
        {
            var cards = _deckCreator.Deck;
            
            _playerWithOneCard = new Player(new HumanCategorySelector());
            _playerWithNoCards = new Player(new HumanCategorySelector());
            _playerWithThreeCards = new Player(new HumanCategorySelector());
            _playerAiWithOneCard= new Player(new AiCategorySelector());
            
            _playerWithOneCard.Deck.Enqueue(cards[0]);
            _playerWithThreeCards.Deck.Enqueue(cards[1]);
            _playerWithThreeCards.Deck.Enqueue(cards[2]);
            _playerWithThreeCards.Deck.Enqueue(cards[3]);
            _playerAiWithOneCard.Deck.Enqueue(cards[4]);
            
            
        }
        [TearDown]
        public void TearDown()
        {
            _playerWithNoCards = null;
            _playerWithOneCard = null;
            _playerWithThreeCards = null;
            _playerAiWithOneCard = null;

        }
        [Test]
        public void IsRemovePlayersWithoutCardsRemovePLayersWithNoCards()
        {
            var players = new Players(new List<Player>
            {
                _playerWithNoCards,
                _playerWithOneCard,
                _playerAiWithOneCard
            });
            players.RemovePlayersWithoutCards();
            
            Assert.AreEqual(2, players.PlayersList.Count);
        }

        [Test]
        [Ignore("Function not implemented")]
        public void SwapActivePlayerChangeActivePlayerToNextInList()
        {
            var players = new Players(new List<Player>
            {
                _playerWithNoCards,
                _playerWithOneCard,
                _playerAiWithOneCard
            });
            players.ActivePlayer = _playerWithNoCards;
            
            players.SwapActivePlayer();
            
            Assert.AreEqual(_playerWithOneCard, players.ActivePlayer );
        }
        
        [Test]
        public void GiveFirstCad()
        {
            var players = new Players(new List<Player>
            {
                _playerWithOneCard,
                _playerAiWithOneCard,
                _playerWithThreeCards,
            });
            var result = players.GiveFirstCard();

            Assert.AreEqual(0, _playerWithOneCard.Deck.Count);
            Assert.AreEqual(3, result.Count);
        }
        
      
    }
}