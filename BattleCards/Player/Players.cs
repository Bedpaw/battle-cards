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
            //TODO what if 2 players out from round?
            var activeIndex = PlayersList.IndexOf(ActivePlayer);
            
            ActivePlayer = (activeIndex == PlayersList.Count - 1)
                ? PlayersList[0]
                : PlayersList[activeIndex + 1];
        }

        public Player GetCardOwner(Card winnerCard)
        {
            return PlayersList.Find(player => ReferenceEquals(player.CardForActualRound, winnerCard));
        }

        public bool OnlyOneAlive() => PlayersList.Count == 1;

        public void GiveOneCardAsPrize(List<Card> prizeContainer)
        {
            prizeContainer.AddRange(GiveFirstCard());
        }
    }
}