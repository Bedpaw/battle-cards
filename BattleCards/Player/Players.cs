using System.Collections.Generic;
using System.Linq;

namespace BattleCards
{
    public class Players
    {
        public List<Player> PlayersList { get; set; }
        public Player ActivePlayer { get; set; }

        public Players(List<Player> playersList)
        {
            PlayersList = playersList;
            ActivePlayer = playersList[0];
        }
        public List<Card>GiveFirstCard()
        {
            var cardsToCompare = new List<Card>();
            PlayersList.ForEach(player => cardsToCompare.Add(player.GiveFirstCard()));
            return cardsToCompare;
        }

        public void RemovePlayersWithoutCards()
        {
            PlayersList = PlayersList.Where(player => player.HasAnyCards).ToList();
        }

        public void SwapActivePlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}