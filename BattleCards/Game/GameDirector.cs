namespace BattleCards
{
    public class GameDirector
    {
        public void Construct(GameBuilder builder)
        {
            builder.BuildCardsDeck();
            builder.BuildPlayersList();
            builder.BuildNumberOfCardsPerPlayer();
            builder.BuildCompareCardsRules();
        }
    }
}