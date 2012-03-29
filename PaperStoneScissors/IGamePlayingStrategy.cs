using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public interface IGamePlayingStrategy
    {
        // TODO: Using the stategy pattern has forced Player and other classes to be public, but for no real reason.
        // What is the best way around this?
        bool CheckIfGameIsComplete(IEnumerable<Player> players);
    }
}
