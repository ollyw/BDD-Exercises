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

        [Given(@"I have chosen a best of (.*) game")]
        public void GivenIHaveChosenABestOfXGames(int maximumNumberOfGames)
        {
            Game = new Game(2, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }

        [Given(@"a game with (.*) player(?:|s) and best of (.*)")]
        public void GivenAGameWithXPlayersAndBestOfY(int numberOfPlayers, int maximumNumberOfGames)
        {
            Game = new Game(numberOfPlayers, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }
    }
}
