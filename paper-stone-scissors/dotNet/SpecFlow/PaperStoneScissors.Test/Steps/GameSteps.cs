using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using NHamcrest.Core;
using PaperStoneScissors.Core;
using PaperStoneScissors.Exceptions;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Test.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private Game<Round> Game
        {
            get
            {
                return ScenarioContext.Current.Get<Game<Round>>();
            }
        }

        private int MePlayerIndex = 0;

        [Then(@"I should lose the game")]
        public void ThenIShouldLoseTheGame()
        {
            Assert.That(Game.GetWinner(), Is.Not(MePlayerIndex));
        }

        [When(@"I lose 1 round(?:|s)")]
        public void WhenILoseXRounds()
        {
            var round = new Round(1);
            round.AddSelection(1, RoundResult.Lose.MakeupObjectFromResult());
            round.AddSelection(2, RoundResult.Win.MakeupObjectFromResult());
            Game.AddRoundResult(round);
        }

        [Then(@"the game should not be complete")]
        public void ThenTheGameShouldNotBeComplete()
        {
            Assert.That(Game.Complete, Is.False());
            Assert.That(() => Game.GetWinner(), Throws.An<GameNotCompletedException>());
        }

        [Then(@"the following results are expected")]
        public void ThenTheFollowResultsAreExpected(IEnumerable<PlayerRank> expectedRanking)
        {
            var actualRanking = Game.GetRanking();

            // TODO: Hamcrest must have support for checking sequences
            Assert.That(actualRanking.SequenceEqual(expectedRanking), Is.True());
        }

        [When(@"I win (\d+) round(?:|s)")]
        public void WhenIWinXRounds(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                var round = new Round(i + 1);
                round.AddSelection(1, RoundResult.Win.MakeupObjectFromResult());
                round.AddSelection(2, RoundResult.Lose.MakeupObjectFromResult());
                Game.AddRoundResult(round);
            }
        }

        [When(@"the following rounds are played")]
        public void WhenTheFollowingRoundsArePlayed(Table table)
        {
            int roundNumber = 0;
            foreach (var row in table.Rows)
            {
                roundNumber++;
                // TODO: Adapt this for multiple sets of players
                var round = new Round(roundNumber);
                round.AddSelection(1, row["Player 1"].ToRoundResult().MakeupObjectFromResult());
                round.AddSelection(2, row["Player 2"].ToRoundResult().MakeupObjectFromResult());
                round.AddSelection(3, row["Player 3"].ToRoundResult().MakeupObjectFromResult());
                Game.AddRoundResult(round);
            }
        }

        [Then(@"the game should be complete")]
        public void ThenTheGameShouldBeComplete()
        {
            Assert.That(Game.Complete, Is.True());
            // TODO: See if we can explicitly check for not throwing an exception
            Assert.That(Game.GetRanking(), Is.Anything());
        }

        [Then(@"player (\d+) should be the winner")]
        public void ThenPlayerNShouldBeTheWinner(int playerNumber)
        {
            Assert.That(Game.GetWinner(), Is.EqualTo(playerNumber));
        }

        [Then(@"there should be no winner")]
        public void ThenThereShouldBeNoWinner()
        {
            Assert.That(() => Game.GetWinner(), Throws.An<GameCompletedWithDrawException>());
        }

        [StepArgumentTransformation]
        public IEnumerable<PlayerRank> PlayerRankTransform(Table rankTable)
        {
            List<PlayerRank> ranking = new List<PlayerRank>();

            foreach (var row in rankTable.Rows)
            {
                var playerRank = new PlayerRank()
                {
                    Player = new Player() { PlayerId = Int32.Parse(row["Player"]) },
                    Rank = Int32.Parse(row["Rank"])
                };

                ranking.Add(playerRank);
            }

            return ranking;
        }
    }
}
