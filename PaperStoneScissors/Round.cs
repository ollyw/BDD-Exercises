using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public class Round
    {
        private IDictionary<int, GameObject> selections = new Dictionary<int, GameObject>();

        public void AddSelection(int player, GameObject gameObject)
        {
            selections.Add(player, gameObject);
        }

        public IDictionary<int, RoundResult> GetResults()
        {
            var results = new Dictionary<int, RoundResult>();

            foreach (var selection in selections)
            {
                RoundResult result;
                var comparisions = from s in selections
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
                results = (from s in selections
                           select new { Key = s.Key, Value = RoundResult.Draw }).ToDictionary(x => x.Key, y => y.Value); 
            }

            return results;
        }
    }

    internal static class GameObjectHelper
    {
        public static RoundResult Compare(this GameObject source, GameObject target)
        {
            if (source == target)
            {
                return RoundResult.Draw;
            }
            else if (source == GameObject.Scissors && target == GameObject.Paper
                || source == GameObject.Paper && target == GameObject.Stone
                || source == GameObject.Stone && target == GameObject.Scissors)
            {
                return RoundResult.Win;
            }
            else
            {
                return RoundResult.Lose;
            }

        }
    }
}
