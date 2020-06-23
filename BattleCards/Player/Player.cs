using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class Player
    {
        public Player(ICategorySelector categorySelector) => CategorySelector = categorySelector;
        public ICategorySelector CategorySelector { get; set; }
        public Queue<Card> Deck { get; set; } = new Queue<Card>();
        public Card CardForActualRound { get; set; }
        public Card GiveFirstCard() => CardForActualRound = Deck.Dequeue();
        public bool HasAnyCards => Deck.Count != 0;
        public void TakeAllCards(List<Card> cardsToAdd) => cardsToAdd.ForEach(card => Deck.Enqueue(card));
        
    }
}