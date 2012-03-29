using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class BestOfGameSteps
    {
        private Game Game
        {
            set
            {
                ScenarioContext.Current.Set<Game>(value);
            }
        }

        [Given(@"I have chosen a best of (.*) game(?:|s)")]
        public void GivenIHaveChosenABestOfXGame(int games)
        {
            Game = new Game(3, 2, GameType.BestOf);
        }
    }
}
