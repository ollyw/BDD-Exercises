using System.Collections.Generic;
using System.Linq;
using PaperStoneScissors.Core;

namespace PaperStoneScissors.Strategies
{
    public class FirstToGamePlayingStrategy : IGamePlayingStrategy
    {
        private readonly int winningNumberOfRounds;

        public FirstToGamePlayingStrategy(int winningNumberOfRounds)
        {
            this.winningNumberOfRounds = winningNumberOfRounds;    
        }

        public bool CheckIfGameIsComplete(IEnumerable<Player> players)
        {
            int maxWins = players.Max(x => x.Wins);

            return maxWins == winningNumberOfRounds;
        }
    }
}
