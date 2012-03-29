using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public class BestOfGamePlayingStrategy : IGamePlayingStrategy
    {
        private readonly int maximumNumberOfRounds;

        public BestOfGamePlayingStrategy(int maximumNumberOfRounds)
        {
            this.maximumNumberOfRounds = maximumNumberOfRounds;
        }

        public bool CheckIfGameIsComplete(IEnumerable<Player> players)
        {
            return players.First().Rounds.Count == 2;
        }
    }
}
