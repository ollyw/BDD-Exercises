using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
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
