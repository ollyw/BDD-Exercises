using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.PageObjects;
using PaperStoneScissors.Test.PageObjects;
using OpenQA.Selenium;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class WebSteps
    {
        RoundSelectionPage roundSelectionPage;

        [Given(@"I choose a single player first to (\d+) game")]
        public void GivenIChooseASinglePlayerFirstToXGame(int firstTo)
        {
            var page = new GameSelectionPage();
            page.SetNumberOfGames(1);
            roundSelectionPage = page.Submit();
        }

        [When(@"I make (\d+) choices")]
        public void WhenIMakeXChoices(int numberOfChoices)
        {
            for (int i = 0; i < numberOfChoices; i++)
            {
                roundSelectionPage.SelectPaper();
                var roundResultsPage = roundSelectionPage.Submit();
                roundResultsPage.Continue();
            }
        }

        // TODO: Undo this hack in the naming of the step
        [Then(@"the web game should be complete")]
        public void ThenThisHackSucks()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the winner of the game")]
        public void ThenIShouldSeeTheWinnerOfTheGame()
        {
            //ScenarioContext.Current.Pending();
        }

        public object page { get; set; }
    }
}
