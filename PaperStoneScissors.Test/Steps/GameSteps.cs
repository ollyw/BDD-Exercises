using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
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
            game = new Game(winningNumberOfRounds);
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
    }

}
