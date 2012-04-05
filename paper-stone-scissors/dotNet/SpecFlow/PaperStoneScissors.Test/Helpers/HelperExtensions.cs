using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Core;

namespace PaperStoneScissors.Test.Helpers
{
    internal static class HelperExtensions
    {
        public static RoundResult ToRoundResult(this string value)
        {
            return (RoundResult)Enum.Parse(typeof(RoundResult), value, true);
        }

        public static PaperStoneScissorsGameObject MakeupObjectFromResult(this RoundResult result)
        {
            // TODO: This feels extraordinarily hacky
            switch (result)
            {
                case RoundResult.Draw: return PaperStoneScissorsGameObject.Paper;
                case RoundResult.Lose: return PaperStoneScissorsGameObject.Scissors;
                case RoundResult.Win: return PaperStoneScissorsGameObject.Stone;
                default: throw new NotImplementedException();
            }
        }
    }
}
