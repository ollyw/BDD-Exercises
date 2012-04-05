using System.Collections.Generic;
using System.Linq;

namespace PaperStoneScissors.Core
{
    public class Player
    {
        public int PlayerId { get; set; }
        public IList<PlayerRound> Rounds { get; private set; }

        public Player()
        {
            Rounds = new List<PlayerRound>();
        }

        public int Wins
        {
            get
            {
                return Rounds.Count(x => x.Result == RoundResult.Win);
            }
        }
    }
}
