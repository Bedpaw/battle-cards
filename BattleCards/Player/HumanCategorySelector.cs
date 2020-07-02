using System;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class HumanCategorySelector : ICategorySelector
    {
        public string SelectCategory(Card cardToChooseCategory)
        {   Console.WriteLine($"You chose {cardToChooseCategory.Name} with stats below:\n");
            
            foreach (var (key, value) in cardToChooseCategory.CardStats)
            {
                Console.WriteLine($"{value.Name}: {value.Value}");
            }
            Console.WriteLine("Please choose Category to compare: ");
            return Console.ReadLine();
        }
    }
}