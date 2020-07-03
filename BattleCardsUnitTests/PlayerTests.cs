using System.Collections.Generic;
using BattleCards;
using BattleCards.Deck;
using NUnit.Framework;

namespace BattleCardsUnitTests
{
    public class PlayerTests
    {
        private DeckCreator _deckCreator = new DeckCreator(2);
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestGiveFirstCard()
        {
            var player = new Player(new HumanCategorySelector());
            player.Deck.Enqueue(_deckCreator.Deck[0]);
            player.Deck.Enqueue(_deckCreator.Deck[1]);
            
            player.GiveFirstCard();
            
            Assert.AreEqual(_deckCreator.Deck[0], player.CardForActualRound );
        }
        
    }
}