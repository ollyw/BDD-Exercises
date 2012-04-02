using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PaperStoneScissors;
using MbUnit.Framework;
using NHamcrest.Core;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class ObjectComparison
    {
        private Round round = new Round();

        [Then(@"the result for player (\d+) is (\w+)")]
        public void ThenTheResultForPlayerXIsY(int player, RoundResult expectedResult)
        {
            var actualResult = round.GetResults()[player];
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [When(@"player (\d+) choses (\w+)")]
        public void WhenPlayerXChosesY(int player, GameObject gameObject)
        {
            round.AddSelection(player, gameObject);
        }
    }
}
