using System.Collections.Generic;

namespace PaperStoneScissors.Core
{
    public interface IRound
    {
        IDictionary<int, RoundResult> GetResults();
        int Number { get; }
    }
}
