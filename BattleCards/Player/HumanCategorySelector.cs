using System;
using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards
{
    public class HumanCategorySelector : ICategorySelector
    {
        public string SelectCategory(Card cardToChooseCategory)
        {
            string input;
            var validNumber = new List<string>{"1", "2", "3", "4"};
            
            do { input = Console.ReadLine(); } while (!validNumber.Contains(input));

            var intInput = int.Parse(input);
            intInput--;
            input = intInput.ToString();
           
            return input;
        }
    }
}