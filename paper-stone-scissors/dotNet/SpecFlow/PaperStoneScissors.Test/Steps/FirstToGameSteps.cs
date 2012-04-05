using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class FirstToGameSteps
    {
        private Game<PaperStoneScissorsRound> Game
        {
            set
            {
                ScenarioContext.Current.Set<Game<PaperStoneScissorsRound>>(value);
            }
        }

        [Given(@"I have chosen a first to (\d*) game")]
        public void GivenIHaveChosenAFirstToXGames(int winningNumberOfRounds)
        {
            Game = new Game<PaperStoneScissorsRound>(2, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }

        [Given(@"a game with (\d*) players and first to (\d*)")]
        public void GivenAGameWithXPlayersAndFirstToYGames(int numberOfPlayers, int winningNumberOfRounds)
        {
            Game = new Game<PaperStoneScissorsRound>(numberOfPlayers, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }
    }
}
