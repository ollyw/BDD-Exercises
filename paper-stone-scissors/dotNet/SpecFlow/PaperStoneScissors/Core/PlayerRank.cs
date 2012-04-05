namespace PaperStoneScissors.Core
{
    public class PlayerRank
    {
        // TODO: Rename Player to PlayerId and decouple scenarios
        public int Player { get; set; }
        public int Rank { get; set; }

        public override bool Equals(object obj)
        {
            var rank = obj as PlayerRank;

            if (rank == null)
            {
                return false;
            }

            return this.Player == rank.Player && this.Rank == rank.Rank; 
        }

        public override int GetHashCode()
        {
            return Player.GetHashCode() ^ Rank.GetHashCode();
        }
    }
}
