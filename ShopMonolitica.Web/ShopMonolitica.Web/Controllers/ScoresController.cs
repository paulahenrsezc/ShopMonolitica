using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Orders;
using ShopMonolitica.Web.Data.Models.Scores;

namespace ShopMonolitica.Web.Controllers
{
    public class ScoresController : Controller
    {
        private readonly IScoresService scoresService;
        public ScoresController(IScoresService scoresService)
        {
           this.scoresService = scoresService;
        }

        // GET: Scores
        public ActionResult Index()
        {
            var result = this.scoresService.GetScores();

            if (!result.Success)
                ViewBag.message = result.Message;

            var scores = (List<ScoresGetModel>)result.Data;
            scores = scores.OrderByDescending(s => s.studentid).ToList();

            return View(scores);
        }

        // GET: Scores/Details/5
        public ActionResult Details(string id)
        {
            var result = this.scoresService.GetScore(id);
            if (!result.Success)
                ViewBag.message = result.Message;

            var scores = (ScoresGetModel)result.Data;
            return View(scores);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoresSaveModel scoresSave)
        {
            try
            {
                this.scoresService.SaveScores(scoresSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(string id)
        {
            var scores = this.scoresService.GetScore(id);
            return View(scores);
        }

        // POST: Scores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoresUpdateModel scoresUpdate)
        {
            try
            {
                this.scoresService.UpdateScores(scoresUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
