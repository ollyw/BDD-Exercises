using MbUnit.Framework;
using NHamcrest.Core;
using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using TechTalk.SpecFlow;

namespace PaperStoneScissors.Test.Steps
{
    [Binding]
    public class ObjectComparison
    {
        private Round round = new Round(1);

        [Then(@"the result for player (\d+) is (\w+)")]
        public void ThenTheResultForPlayerXIsY(int player, RoundResult expectedResult)
        {
            var actualResult = round.GetResults()[player];
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [When(@"player (\d+) choses (\w+)")]
        public void WhenPlayerXChosesY(int player, PaperStoneScissorsGameObject gameObject)
        {
            round.AddSelection(player, gameObject);
        }
    }
}
