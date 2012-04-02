using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public interface IRound
    {
        IDictionary<int, RoundResult> GetResults();
    }
}
