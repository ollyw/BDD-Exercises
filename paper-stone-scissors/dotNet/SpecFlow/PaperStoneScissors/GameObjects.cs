using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    public enum GameObject
    {
        Paper = 0,
        Stone = 1,
        Scissors = 2
    }

    public static class GameObjectHelper
    {
        public static GameObject ChoseRandom()
        {
            Random rand = new Random();
            var val = (GameObject)rand.Next(0, 3);
            return val;
        }

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
