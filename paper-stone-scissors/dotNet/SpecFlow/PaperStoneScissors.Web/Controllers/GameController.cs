using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperStoneScissors.Web.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ActionResult NewGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewGameDetails()
        {
            Game = new Game<PaperStoneScissorsRound>(2, new BestOfGamePlayingStrategy(3));
            return RedirectToAction("PlayRound");
        }

        [HttpGet]
        public ActionResult PlayRound()
        {
            if (Game == null)
                return RedirectToAction("NewGame");

            return View();
        }

        [HttpPost]
        public ActionResult SaveRound(GameObject chosenObject)
        {
            if (Game == null)
                return RedirectToAction("NewGame");

            var autoCompleted = GameObjectHelper.ChoseRandom();

            var round = new PaperStoneScissorsRound(Game.Rounds.Count + 1);
            round.AddSelection(1, chosenObject);
            round.AddSelection(2, autoCompleted);
            Game.AddRoundResult(round);

            return View(Game.Rounds);
        }

        private Game<PaperStoneScissorsRound> Game
        {
            get
            {
                return this.Session["game"] as Game<PaperStoneScissorsRound>;
            }
            set
            {
                this.Session.Add("game", value);
            }
        }
    }
}
