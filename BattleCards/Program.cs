using System;

namespace BattleCards
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.DisplayGameOptions();
            var game = MainMenu.CreateGameInChosenMode();
            game.GameLogic();
        }
    }
}
