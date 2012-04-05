using System;
using System.Collections.Generic;
using System.Linq;
using PaperStoneScissors.Exceptions;
using PaperStoneScissors.Strategies;

namespace PaperStoneScissors.Core
{
    public class Game<RoundType> where RoundType : IRound
    {
        private IDictionary<int, Player> Players { get; set; }
        private IGamePlayingStrategy PlayingStrategy { get; set; }
        public IList<RoundType> Rounds { get; private set; }
        public bool Complete { get; private set; }

        public Game(IEnumerable<Player> players, IGamePlayingStrategy playingStrategy)
        {
            if (players.Count() < 2)
            {
                throw new ArgumentOutOfRangeException("numberOfPlayers", players.Count(), "A game must have two more players");
            }

            Players = players.ToDictionary(p => p.Id);
            Rounds = new List<RoundType>();

            this.PlayingStrategy = playingStrategy;
        }

        public void AddRoundResult(RoundType round)
        {
            if (Complete)
            {
                throw new GameAlreadyCompletedException();
            }

            var playerResults = round.GetResults();
            Rounds.Add(round);

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

            Complete = PlayingStrategy.CheckIfGameIsComplete(Players.Values);
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

            return ranking.First().Player.Id;
        }

        public IEnumerable<PlayerRank> GetRanking()
        {
            if (!Complete)
            {
                throw new GameNotCompletedException();
            }

            var orderedPlayers = from player in Players.Values
                          orderby player.Wins descending, player.Id
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
                ranking.Add(new PlayerRank() { Player = player, Rank = currentRank });
            }

            var orderedRanking = from rank in ranking
                                 orderby rank.Rank, rank.Player.Id
                                 select rank;

            return orderedRanking.ToArray();
        }
    }
}
