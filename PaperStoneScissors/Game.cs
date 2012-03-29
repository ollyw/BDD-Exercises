using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public class Game
    {
        private IDictionary<int, Player> Players;
        private IGamePlayingStrategy playingStrategy;

        public Game(int numberOfPlayers, IGamePlayingStrategy playingStrategy)
        {
            Players = new Dictionary<int, Player>();
            for (int p = 0; p < numberOfPlayers; p++)
            {
                var id = p + 1;
                Players.Add(id, new Player() { PlayerId = id });
            }

            this.playingStrategy = playingStrategy;
        }

        public void AddRoundResult(RoundResult[] playerResults)
        {
            if (playerResults.Length != Players.Count)
                throw new ArgumentException("incorrect number of results");

            for(var p = 0; p < playerResults.Length; p++)
            {
                var id = p + 1;
                Players[id].Rounds.Add(new PlayerRound()
                {
                    Result = playerResults[p],
                    Round = Players[id].Rounds.Count + 1
                });
            }
        }
    
        public int GetWinner()
        {
            return GetRanking().First().Player;
        }

        private void CheckGameIsComplete()
        {
            if (!playingStrategy.CheckIfGameIsComplete(Players.Values))
            {
                throw new GameNotCompletedException();
            }
        }

        public IEnumerable<PlayerRank> GetRanking()
        {
            CheckGameIsComplete();

            var orderedPlayers = from player in Players.Values
                          orderby player.Wins descending, player.PlayerId
                          select player;

            int currentRank = 0;
            int lastNumberOfWins = 0;
            var ranking = new List<PlayerRank>();

            foreach (var player in orderedPlayers)
            {
                if (lastNumberOfWins != player.Wins)
                {
                    lastNumberOfWins = player.Wins;
                    currentRank++;
                }
                ranking.Add(new PlayerRank() { Player = player.PlayerId, Rank = currentRank });
            }

            var orderedRanking = from rank in ranking
                                 orderby rank.Rank, rank.Player
                                 select rank;

            return orderedRanking.ToArray();
        }
    }
}
