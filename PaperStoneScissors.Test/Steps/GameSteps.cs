using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using MbUnit.Framework;
using NHamcrest.Core;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private Game game;
        private int MePlayerIndex = 0;

        [Given(@"I have chosen a first to (.*) game")]
        public void GivenIHaveChosenAFirstToXGame(int winningNumberOfRounds)
        {
            game = new Game(winningNumberOfRounds, 2);
        }

        [Then(@"I should lose the game")]
        public void ThenIShouldLoseTheGame()
        {
            Assert.That(game.GetWinner(), Is.Not(MePlayerIndex));
        }

        [When(@"I lose one round")]
        public void WhenILoseOneRound()
        {
            game.AddRoundResult(new RoundResult[] {RoundResult.Lose, RoundResult.Win});
        }

        [Then(@"the game should not be complete")]
        public void ThenTheGameShouldNotBeComplete()
        {
            Assert.That(() => game.GetWinner(), Throws.An<GameNotCompletedException>());
        }

        [Given(@"a game with (.*) players and first to (.*) game")]
        public void GivenAGameWithXPlayersAndFirstToYGame(int numberOfPlayers, int winningNumberOfRounds)
        {
            game = new Game(winningNumberOfRounds, numberOfPlayers);
        }

        [Then(@"the following results are expected")]
        public void ThenTheFollowResultsAreExpected(Table table)
        {
            IEnumerable<PlayerRank> expectedRanking = table.CreateSet<PlayerRank>();

            var actualRanking = game.GetRanking();

            Assert.That(actualRanking.SequenceEqual(expectedRanking), Is.True());
        }

        [When(@"the following rounds are played")]
        public void WhenTheFollowingRoundsArePlayed(Table table)
        {
            foreach (var row in table.Rows)
            {
                RoundResult[] round = new RoundResult[3];
                round[0] = (RoundResult)Enum.Parse(typeof(RoundResult), row["Player 1"], true);
                round[1] = (RoundResult)Enum.Parse(typeof(RoundResult), row["Player 2"], true);
                round[2] = (RoundResult)Enum.Parse(typeof(RoundResult), row["Player 3"], true);
                game.AddRoundResult(round);
            }
            
        }
    }
}
