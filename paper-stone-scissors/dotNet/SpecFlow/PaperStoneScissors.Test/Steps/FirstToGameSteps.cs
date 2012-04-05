using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;
using TechTalk.SpecFlow;
using PaperStoneScissors.Test.Helpers;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class FirstToGameSteps
    {
        private Game<Round> Game
        {
            set
            {
                ScenarioContext.Current.Set<Game<Round>>(value);
            }
        }

        [Given(@"I have chosen a first to (\d*) game")]
        public void GivenIHaveChosenAFirstToXGames(int winningNumberOfRounds)
        {
            var players = HelperExtensions.GeneratePlayers(2);
            Game = new Game<Round>(players, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }

        [Given(@"a game with (\d*) players and first to (\d*)")]
        public void GivenAGameWithXPlayersAndFirstToYGames(int numberOfPlayers, int winningNumberOfRounds)
        {
            var players = HelperExtensions.GeneratePlayers(numberOfPlayers);
            Game = new Game<Round>(players, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }
    }
}
