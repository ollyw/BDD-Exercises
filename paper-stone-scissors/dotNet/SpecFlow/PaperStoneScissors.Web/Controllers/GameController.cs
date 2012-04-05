using System.Web.Mvc;
using PaperStoneScissors.Core;
using PaperStoneScissors.PaperStoneScissors;
using PaperStoneScissors.Strategies;

namespace PaperStoneScissors.Web.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ViewResult NewGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewGameDetails(string playerName)
        {
            var players = new Player[] {
                new Player() {Id = 1, Name = playerName },
                new Player() {Id = 2, Name = "Computer" }
            };

            Game = new Game<Round>(players, new BestOfGamePlayingStrategy(3));
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
        public ActionResult SaveRound(PaperStoneScissorsGameObject chosenObject)
        {
            if (Game == null)
                return RedirectToAction("NewGame");

            var autoCompleted = GameObjectHelper.ChoseRandom();

            var round = new Round(Game.Rounds.Count + 1);
            round.AddSelection(1, chosenObject);
            round.AddSelection(2, autoCompleted);
            Game.AddRoundResult(round);

            if (Game.Complete)
            {
                return RedirectToAction("Results");
            }

            return View(Game.Rounds);
        }

        [HttpGet]
        public ActionResult Results()
        {
            var results = Game.GetRanking();

            return View(results);
        }

        private Game<Round> Game
        {
            get
            {
                return this.Session["game"] as Game<Round>;
            }
            set
            {
                this.Session.Add("game", value);
            }
        }
    }
}
