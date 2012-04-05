using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using NHamcrest.Core;

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
            var game = new Game<PaperStoneScissorsRound>(numberOfPlayers, new BestOfGamePlayingStrategy(1));
        }

        [Test]
        public void GameShouldNotAllowAdditionalRoundsOnceComplete()
        {
            var round1 = new PaperStoneScissorsRound(1);
            round1.AddSelection(1, GameObject.Scissors);
            round1.AddSelection(2, GameObject.Paper);

            var round2 = new PaperStoneScissorsRound(2);
            round2.AddSelection(1, GameObject.Scissors);
            round2.AddSelection(2, GameObject.Paper);

            var numberOfPlayers = 2;

            var game = new Game<PaperStoneScissorsRound>(numberOfPlayers, new FirstToGamePlayingStrategy(1));

            game.AddRoundResult(round1);
            
            Assert.That(() => game.AddRoundResult(round2), Throws.An<GameAlreadyCompletedException>());
        }
    }
}
