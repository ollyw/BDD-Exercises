using System;
using PaperStoneScissors.Core;

namespace PaperStoneScissors.PaperStoneScissors
{
    public enum PaperStoneScissorsGameObject
    {
        Paper = 0,
        Stone = 1,
        Scissors = 2
    }

    public static class GameObjectHelper
    {
        public static PaperStoneScissorsGameObject ChoseRandom()
        {
            Random rand = new Random();
            var val = (PaperStoneScissorsGameObject)rand.Next(0, 3);
            return val;
        }

        public static RoundResult Compare(this PaperStoneScissorsGameObject source, PaperStoneScissorsGameObject target)
        {
            if (source == target)
            {
                return RoundResult.Draw;
            }
            else if (source == PaperStoneScissorsGameObject.Scissors && target == PaperStoneScissorsGameObject.Paper
                || source == PaperStoneScissorsGameObject.Paper && target == PaperStoneScissorsGameObject.Stone
                || source == PaperStoneScissorsGameObject.Stone && target == PaperStoneScissorsGameObject.Scissors)
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
