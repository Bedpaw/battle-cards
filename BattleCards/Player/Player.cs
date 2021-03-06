﻿using System;
using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class Player
    {
        private readonly List<string> Nicks = new List<string> {"Andrzej", "Stefano", "Wojtas"};
        public string Nick { get; set; } 

        public Player(ICategorySelector categorySelector)
        {
            CategorySelector = categorySelector;
            Nick = Nicks[new Random().Next(0, Nicks.Count)] + new Random().Next(1920, 2020);
        }
        public ICategorySelector CategorySelector { get; set; }
        public Queue<Card> Deck { get; set; } = new Queue<Card>();
        public Card CardForActualRound { get; set; }
        public Card GiveFirstCard() => CardForActualRound = Deck.Dequeue();
        public bool HasAnyCards => Deck.Count != 0;
        
        public void TakeAllCards(List<Card> cardsToAdd) => cardsToAdd.ForEach(card => Deck.Enqueue(card));
        
    }
}