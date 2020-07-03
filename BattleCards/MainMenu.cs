using System;
using System.Collections.Generic;
using BattleCards.Interfaces;

namespace BattleCards
{
    public static class MainMenu
    {    private static List<string> gameOptions = new List<string>
        {
            "Human vs AI",
            "Human vs Human",
            "Human vs Human vs Ai vs Ai",
            "Ai vs Ai",
            "Full default game"
        };
        public static void DisplayGameOptions()
        {

            foreach (var option in gameOptions)
            {
                Console.WriteLine($"Play {option} mode");
            }
            Console.WriteLine("\nPlease chose game mode:");
        }

        public static Game CreateGameInChosenMode()
        {
            int userChoice;
            do
            {
                var input = Console.ReadLine();
                userChoice = int.Parse(input);
            } while (userChoice < 0 && userChoice < gameOptions.Count);

            return CreateGame(userChoice - 1);
        }

        private static Game CreateGame(int userChoice)
        {
            var director = new GameDirector();

            GameBuilder builder = userChoice switch
            {
                0 => new HumanVersusAiBuilder(),
                1 => new HumanVersusHumanGameBuilder(),
                2 => new TwoHumanTwoAiBuilder(),
                3 => new AiVersusAiBuilder(),
                _ => throw new IndexOutOfRangeException()
            };

            director.Construct(builder);
            return builder.GetResult();
        }
    }
}