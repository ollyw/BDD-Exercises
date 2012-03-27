using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors.Test.Helpers
{
    public static class HelperExtensions
    {
        public static RoundResult ToRoundResult(this string value)
        {
            return (RoundResult)Enum.Parse(typeof(RoundResult), value, true);
        }
    }
}
