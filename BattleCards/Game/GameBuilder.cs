namespace BattleCards
{
    public abstract class GameBuilder
    {
        public abstract void BuildCardsDeck();
        public abstract void BuildPlayersList();
        public abstract void BuildNumberOfCardsPerPlayer();
        public abstract void BuildCompareCardsRules();
        public abstract void BuildDisplay();

        public abstract Game GetResult();
    }
}