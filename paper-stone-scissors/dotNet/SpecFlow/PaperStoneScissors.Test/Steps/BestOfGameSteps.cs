using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;
using TechTalk.SpecFlow;
using PaperStoneScissors.Test.Helpers;

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
            var players = HelperExtensions.GeneratePlayers(2);
            Game = new Game<Round>(players, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }

        [Given(@"a game with (.*) player(?:|s) and best of (.*)")]
        public void GivenAGameWithXPlayersAndBestOfY(int numberOfPlayers, int maximumNumberOfGames)
        {
            var players = HelperExtensions.GeneratePlayers(numberOfPlayers);
            Game = new Game<Round>(players, new BestOfGamePlayingStrategy(maximumNumberOfGames));
        }
    }
}
