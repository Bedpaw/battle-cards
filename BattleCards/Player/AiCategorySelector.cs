using System;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class AiCategorySelector : ICategorySelector
    {
        public string SelectCategory(Card cardToChooseCategory)
        {
            return new Random().Next(1,4).ToString();
        }
    }
}