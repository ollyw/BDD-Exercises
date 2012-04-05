using System.Collections.Generic;
using System.Linq;

namespace PaperStoneScissors.Core
{
    public class Player
    {
        public int Id { get; set; }
        public IList<PlayerRound> Rounds { get; private set; }
        public string Name { get; set; } 
        
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

            return otherPlayer.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return 45 ^ Id.GetHashCode();
        }
    }
}
