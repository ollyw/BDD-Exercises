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

        public override bool Equals(object obj)
        {
            var otherPlayer = obj as Player;

            if (otherPlayer == null)
            {
                return false;
            }

            return otherPlayer.PlayerId == this.PlayerId;
        }

        public override int GetHashCode()
        {
            return 45 ^ PlayerId.GetHashCode();
        }
    }
}
