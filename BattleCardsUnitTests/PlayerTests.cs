using System.Collections.Generic;
using BattleCards;
using NUnit.Framework;

namespace BattleCardsUnitTests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestGiveFirstCard()
        {
            var player = new Player(new HumanCategorySelector()) {Deck = new Queue<Card>()};
            player.Deck.Enqueue(new Card("First", "1", "2", "3", "4"));
            player.Deck.Enqueue(new Card("Second", "1", "2", "3", "4"));
            
            player.GiveFirstCard();
            
            Assert.AreEqual("First", player.CardForActualRound.Name );
        }
        
    }
}