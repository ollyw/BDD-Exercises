using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class WebSteps
    {
        [Given(@"I choose a single player first to (\d+) game")]
        public void GivenIChooseASinglePlayerFirstToXGame(int firstTo)
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I make (\d+) choices")]
        public void WhenIMakeXChoices(int numberOfChoices)
        {
            //ScenarioContext.Current.Pending();
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
    }
}
