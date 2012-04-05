using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class BestOfGameSteps
    {
        private Game<Round> Game
        {
            set
            {
                ScenarioContext.Current.Set<Game<Round>>(value);
            }
        }

        [Given(@"I have chosen a best of (.*) game")]
        public void GivenIHaveChosenABestOfXGames(int maximumNumberOfGames)
        {
            Game = new Game<Round>(2, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }

        [Given(@"a game with (.*) player(?:|s) and best of (.*)")]
        public void GivenAGameWithXPlayersAndBestOfY(int numberOfPlayers, int maximumNumberOfGames)
        {
            Game = new Game<Round>(numberOfPlayers, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }
    }
}
