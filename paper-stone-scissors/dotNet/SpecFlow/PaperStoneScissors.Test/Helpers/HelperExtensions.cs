using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors.Test.Helpers
{
    internal static class HelperExtensions
    {
        public static RoundResult ToRoundResult(this string value)
        {
            return (RoundResult)Enum.Parse(typeof(RoundResult), value, true);
        }

        public static GameObject MakeupObjectFromResult(this RoundResult result)
        {
            // TODO: This feels extraordinarily hacky
            switch (result)
            {
                case RoundResult.Draw: return GameObject.Paper;
                case RoundResult.Lose: return GameObject.Scissors;
                case RoundResult.Win: return GameObject.Stone;
                default: throw new NotImplementedException();
            }
        }
    }
}
