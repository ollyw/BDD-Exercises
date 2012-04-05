namespace PaperStoneScissors.Core
{
    public class PlayerRank
    {
        // TODO: Rename Player to PlayerId and decouple scenarios
        public Player Player { get; set; }
        public int Rank { get; set; }

        public override bool Equals(object obj)
        {
            var playerRank = obj as PlayerRank;

            if (playerRank == null)
            {
                return false;
            }

            return this.Player.Equals(playerRank.Player) && this.Rank == playerRank.Rank; 
        }

        public override int GetHashCode()
        {
            return Player.GetHashCode() ^ Rank.GetHashCode();
        }
    }
}
