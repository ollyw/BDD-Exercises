using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;
using TechTalk.SpecFlow;

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
            Game = new Game<Round>(2, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }

        [Given(@"a game with (\d*) players and first to (\d*)")]
        public void GivenAGameWithXPlayersAndFirstToYGames(int numberOfPlayers, int winningNumberOfRounds)
        {
            Game = new Game<Round>(numberOfPlayers, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }
    }
}
