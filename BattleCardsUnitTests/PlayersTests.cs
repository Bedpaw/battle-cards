using System.Collections.Generic;
using BattleCards;
using NUnit.Framework;

namespace BattleCardsUnitTests
{
    public class PlayersTests
    {
        private Player _playerWithOneCard;
        private Player _playerWithThreeCards;
        private Player _playerWithNoCards;
        private Player _playerAiWithOneCard;
        
        [SetUp]
        public void Setup()
        {
            _playerWithOneCard = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            _playerWithNoCards = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            _playerWithThreeCards = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            _playerAiWithOneCard= new Player(new AiCategorySelector()) {Deck = new Queue<Card>()};
            
            _playerWithOneCard.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            _playerAiWithOneCard.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            
            _playerWithThreeCards.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            _playerWithThreeCards.Deck.Enqueue(new Card("Second", "1", "2", "3", "4"));
            _playerWithThreeCards.Deck.Enqueue(new Card("Third", "1", "2", "3", "4"));
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