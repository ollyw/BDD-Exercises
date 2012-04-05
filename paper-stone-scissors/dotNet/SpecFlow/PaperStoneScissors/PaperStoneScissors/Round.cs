using System.Collections.Generic;
using System.Linq;
using PaperStoneScissors.Core;

namespace PaperStoneScissors.PaperStoneScissors
{
    public class Round : IRound
    {
        public IDictionary<int, PaperStoneScissorsGameObject> Selections { get; private set; }
        public int Number { get; private set; }

        public Round(int roundNumber)
        {
            Number = roundNumber;
            Selections = new Dictionary<int, PaperStoneScissorsGameObject>();
        }

        public void AddSelection(int player, PaperStoneScissorsGameObject gameObject)
        {
            Selections.Add(player, gameObject);
        }

        public IDictionary<int, RoundResult> GetResults()
        {
            var results = new Dictionary<int, RoundResult>();

            foreach (var selection in Selections)
            {
                RoundResult result;
                var comparisions = from s in Selections
                             where s.Key != selection.Key
                             select selection.Value.Compare(s.Value);

                if (comparisions.All(x => x == RoundResult.Draw))
                {
                    result = RoundResult.Draw;
                }
                else if (comparisions.All(x => x == RoundResult.Win))
                {
                    result = RoundResult.Win;
                }
                else if (comparisions.Any(x => x == RoundResult.Lose))
                {
                    result = RoundResult.Lose;
                }
                else
                {
                    result = RoundResult.Lose;
                }

                results[selection.Key] = result;
            }

            if (results.All(x => x.Value == RoundResult.Lose))
            {
                results = (from s in Selections
                           select new { Key = s.Key, Value = RoundResult.Draw })
                           .ToDictionary(x => x.Key, y => y.Value); 
            }

            return results;
        }
    }
}
