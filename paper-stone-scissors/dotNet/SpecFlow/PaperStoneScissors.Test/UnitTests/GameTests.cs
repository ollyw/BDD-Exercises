using System.Linq;
using MbUnit.Framework;
using NHamcrest.Core;
using PaperStoneScissors.Core;
using PaperStoneScissors.Exceptions;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;

namespace PaperStoneScissors.Test.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        [Row(-1)]
        [Row(0)]
        [Row(1)]
        [ExpectedArgumentOutOfRangeException]
        public void GameShouldThrowExceptionIfLessThanTwoPlayersAreSelected(int numberOfPlayers)
        {
            var game = new Game<Round>(numberOfPlayers, new BestOfGamePlayingStrategy(1));
        }

        [Test]
        public void GameShouldNotAllowAdditionalRoundsOnceComplete()
        {
            var round1 = new Round(1);
            round1.AddSelection(1, PaperStoneScissorsGameObject.Scissors);
            round1.AddSelection(2, PaperStoneScissorsGameObject.Paper);

            var round2 = new Round(2);
            round2.AddSelection(1, PaperStoneScissorsGameObject.Scissors);
            round2.AddSelection(2, PaperStoneScissorsGameObject.Paper);

            var numberOfPlayers = 2;

            var game = new Game<Round>(numberOfPlayers, new FirstToGamePlayingStrategy(1));

            game.AddRoundResult(round1);
            
            Assert.That(() => game.AddRoundResult(round2), Throws.An<GameAlreadyCompletedException>());
        }

        [Test]
        public void PlayerRankingShouldContainTheNumberOfWins()
        {
            var round1 = new Round(1);
            round1.AddSelection(1, PaperStoneScissorsGameObject.Scissors);
            round1.AddSelection(2, PaperStoneScissorsGameObject.Paper);

            var round2 = new Round(2);
            round2.AddSelection(1, PaperStoneScissorsGameObject.Scissors);
            round2.AddSelection(2, PaperStoneScissorsGameObject.Paper);

            var round3 = new Round(3);
            round3.AddSelection(1, PaperStoneScissorsGameObject.Scissors);
            round3.AddSelection(2, PaperStoneScissorsGameObject.Paper);

            var numberOfPlayers = 2;

            var game = new Game<Round>(numberOfPlayers, new FirstToGamePlayingStrategy(3));

            game.AddRoundResult(round1);
            game.AddRoundResult(round2);
            game.AddRoundResult(round3);

            var ranking = game.GetRanking().ToList();

            Assert.That(ranking.Count, Is.EqualTo(2));
            Assert.That(ranking[0].Player.Wins, Is.EqualTo(3));
            Assert.That(ranking[1].Player.Wins, Is.EqualTo(0));

        }
    }
}
