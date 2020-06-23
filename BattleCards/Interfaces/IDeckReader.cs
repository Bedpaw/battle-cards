using System.Collections.Generic;

namespace BattleCards.Interfaces
{
    public interface IDeckReader
    {
        public List<Card> GetListOfCards(string source);
    }
}