using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using NHamcrest.Core;
using PaperStoneScissors.Test.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private Game Game
        {
            get
            {
                return ScenarioContext.Current.Get<Game>();
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
            // TODO: Does this API need cleaning up/simplifying?
            Game.AddRoundResult(new RoundResult[] {RoundResult.Lose, RoundResult.Win});
        }

        [Then(@"the game should not be complete")]
        public void ThenTheGameShouldNotBeComplete()
        {
            Assert.That(() => Game.GetWinner(), Throws.An<GameNotCompletedException>());
        }

        [Then(@"the following results are expected")]
        public void ThenTheFollowResultsAreExpected(Table table)
        {
            IEnumerable<PlayerRank> expectedRanking = table.CreateSet<PlayerRank>();

            var actualRanking = Game.GetRanking();

            // TODO: Hamcrest must have support for checking sequences
            Assert.That(actualRanking.SequenceEqual(expectedRanking), Is.True());
        }

        [When(@"I win (.*) round(?:|s)")]
        public void WhenIWinXRounds(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                // TODO: Does this API need cleaning up/simplifying?
                Game.AddRoundResult(new RoundResult[] { RoundResult.Win, RoundResult.Lose });
            }
        }


        [When(@"the following rounds are played")]
        public void WhenTheFollowingRoundsArePlayed(Table table)
        {
            foreach (var row in table.Rows)
            {
                // TODO: Adapter this for multiple sets of players
                RoundResult[] round = new RoundResult[3];
                round[0] = row["Player 1"].ToRoundResult();
                round[1] = row["Player 2"].ToRoundResult();
                round[2] = row["Player 3"].ToRoundResult();
                Game.AddRoundResult(round);
            }
        }

        [Then(@"the game should be complete")]
        public void ThenTheGameShouldBeComplete()
        {
            // TODO: See if we can explicitly check for not throwing an exception
            Assert.That(Game.GetRanking(), Is.Anything());
        }
    }
}
