namespace BattleCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = GameCreator.CreateNewGame();
            game.GameLogic();
        }
    }
}
