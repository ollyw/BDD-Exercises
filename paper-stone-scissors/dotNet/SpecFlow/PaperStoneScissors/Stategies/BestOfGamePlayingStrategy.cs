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
            var roundsPlayed = players.First().Rounds.Count;

            if (roundsPlayed == maximumNumberOfRounds)
            {
                return true;
            }

            var orderedPlayers = (from p in players
                             orderby p.Wins descending
                             select p).ToList();

            var leader = orderedPlayers[0];
            var firstRunnerUp = orderedPlayers[1];
            
            var leaderLead = leader.Wins - firstRunnerUp.Wins;
            var roundsLeft = maximumNumberOfRounds - roundsPlayed;

            return (leaderLead > roundsLeft);
            
        }
    }
}
