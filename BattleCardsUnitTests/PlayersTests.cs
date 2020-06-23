using System.Collections.Generic;
using BattleCards;
using NUnit.Framework;

namespace BattleCardsUnitTests
{
    public class PlayersTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void IsRemovePlayersWithoutCardsRemovePLayersWithNoCards()
        {
            var player1 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            var player2 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            
            player1.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            
            var players = new Players(new List<Player>
            {
                player1, player2
            });
            
            players.RemovePlayersWithoutCards();
            
            Assert.AreEqual(1, players.PlayersList.Count);
            
        }
        [Test]
        public void IsRemovePlayersWithoutCardsLeavePlayersWithCards()
        {
            var player1 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            var player2 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            var player3 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            var player4 = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            
            player1.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            player2.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            player3.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            player4.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            
            var players = new Players(new List<Player>
            {
                player1, player2, player3, player4
            });
            
            players.RemovePlayersWithoutCards();
            
            Assert.AreEqual(4, players.PlayersList.Count);
            
        }
      
    }
}