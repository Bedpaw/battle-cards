using System;
using System.Collections.Generic;

namespace BattleCards
{
    public static class MainMenu
    {    
        private static List<string> gameOptions = new List<string>
        {
            "Human vs AI",
            "Human vs Human",
            "Human vs Human vs Ai vs Ai",
            "Ai vs Ai",
            "Blitz Ai vs Ai",
            "Full default game"
        };
        public static void DisplayGameOptions()
        {
            var i = 1;
            foreach (var option in gameOptions)
            {
                Console.WriteLine($"[{i}] Play {option} mode");
                i++;
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
                4 => new BlitzAiVersusAiBuilder(),
                5 => new FullDefaultGameBuilder(),
                _ => throw new IndexOutOfRangeException()
            };

            director.Construct(builder);
            return builder.GetResult();
        }
    }
}