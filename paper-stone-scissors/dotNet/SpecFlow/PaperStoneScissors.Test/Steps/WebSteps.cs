using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.PageObjects;
using PaperStoneScissors.Test.PageObjects;
using OpenQA.Selenium;
using MbUnit.Framework;
using NHamcrest.Core;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class WebSteps
    {
        [Given(@"I choose a single player first to (\d+) game")]
        public void GivenIChooseASinglePlayerFirstToXGame(int firstTo)
        {
            var page = new GameSelectionPage();
            page.SetNumberOfGames(1);
            page.SetPlayerName("TestPlayer");
            page.Submit();
        }

        [When(@"I make (\d+) choices")]
        public void WhenIMakeXChoices(int numberOfChoices)
        {
            var roundSelectionPage = WebDriverPageBase.CurrentPage as RoundSelectionPage;

            for (int i = 0; i < numberOfChoices; i++)
            {
                roundSelectionPage.SelectPaper();
                var roundResultsPage = roundSelectionPage.Submit() as RoundResultsPage;
                if (roundResultsPage != null)
                {
                    roundResultsPage.Continue();
                }
            }
        }

        // TODO: Undo this hack in the naming of the step
        [Then(@"the web game should be complete")]
        public void ThenThisHackSucks()
        {
            Assert.IsInstanceOfType<GameResultsPage>(WebDriverPageBase.CurrentPage);
        }

        // TODO Fix this so that we actually find out who won and verify
        [Then(@"I should see the winner of the game")]
        public void ThenIShouldSeeTheWinnerOfTheGame()
        {
            var gameResults = WebDriverPageBase.CurrentPage as GameResultsPage;
            
            Assert.That(gameResults.WinnerName.Length, Is.GreaterThan(1));
        }
    }
}
