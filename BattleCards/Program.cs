using System;
using System.Runtime.InteropServices.ComTypes;

namespace BattleCards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var director = new GameDirector();
            var choice = 0; //MOCK
            
            GameBuilder builder = choice switch
            {
                0 => new DefaultGameBuilder(),
                1 => new HumanVersusHumanGameBuilder(),
                _ => throw new IndexOutOfRangeException()
            };

            director.Construct(builder);
            
            var game = builder.GetResult();
            game.GameLogic();
        }
    }
}
