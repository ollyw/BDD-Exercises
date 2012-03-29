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
        private Game Game
        {
            set
            {
                ScenarioContext.Current.Set<Game>(value);
            }
        }

        [Given(@"I have chosen a first to (.*) game(?:|s)")]
        public void GivenIHaveChosenAFirstToXGames(int winningNumberOfRounds)
        {
            Game = new Game(2, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }

        [Given(@"a game with (.*) players and first to (.*) game(?:|s)")]
        public void GivenAGameWithXPlayersAndFirstToYGames(int numberOfPlayers, int winningNumberOfRounds)
        {
            Game = new Game(numberOfPlayers, new FirstToGamePlayingStrategy(winningNumberOfRounds));
        }
    }
}
