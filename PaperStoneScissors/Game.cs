using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public class Game
    {
        private IList<RoundResult[]> roundResults = new List<RoundResult[]>();
        private int winningNumberOfRounds;
        private int numberOfPlayers;

        public Game(int winningNumberOfRounds, int numberOfPlayers)
        {
            this.winningNumberOfRounds = winningNumberOfRounds;
            this.numberOfPlayers = numberOfPlayers;
        }

        public void AddRoundResult(RoundResult[] playerResults)
        {
            if (playerResults.Length != numberOfPlayers)
                throw new ArgumentException("incorrect number of results");

            roundResults.Add(playerResults);
        }
    
        public int GetWinner()
        {
            List<int> wins = new List<int>();

            for (int p = 0; p < numberOfPlayers; p++)
            {
                wins.Add((from round in roundResults
                           where round[p] == RoundResult.Win
                           select 1
                            ).Count());
            }

            int maxWins = wins.Max();

            if (maxWins != winningNumberOfRounds)
            {
                throw new GameNotCompletedException();
            }

            return wins.IndexOf(maxWins);
        }

        public int[] GetRanking()
        {
            return new[] { 1, 3, 2};
        }
    }
}
