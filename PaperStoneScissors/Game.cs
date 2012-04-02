using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public class Game
    {
        private IDictionary<int, Player> Players;
        private IGamePlayingStrategy PlayingStrategy;

        public Game(int numberOfPlayers, IGamePlayingStrategy playingStrategy)
        {
            Players = new Dictionary<int, Player>();
            for (int p = 0; p < numberOfPlayers; p++)
            {
                var id = p + 1;
                Players.Add(id, new Player() { PlayerId = id });
            }

            this.PlayingStrategy = playingStrategy;
        }

        public void AddRoundResult(IRound round)
        {
            var playerResults = round.GetResults();

            if (playerResults.Count != Players.Count)
                throw new ArgumentException("incorrect number of results");

            foreach (var playerResult in playerResults)
            {
                Players[playerResult.Key].Rounds.Add(new PlayerRound()
                {
                    Result = playerResult.Value,
                    Round = Players[playerResult.Key].Rounds.Count + 1
                });
            }
        }
    
        public int GetWinner()
        {
            var ranking = GetRanking();

            var numberOfTopRankers = (from r in ranking
                                     where r.Rank == 1
                                     select r).Count();

            if (numberOfTopRankers > 1)
            {
                throw new GameCompletedWithDrawException();
            }

            return ranking.First().Player;
        }

        private void CheckGameIsComplete()
        {
            if (!PlayingStrategy.CheckIfGameIsComplete(Players.Values))
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
            int lastNumberOfWins = -1;
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
