using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Scores;

namespace ShopMonolitica.Web.Controllers
{
    public class ScoresController : Controller
    {
        private readonly IScoresDb scoresDb;
        public ScoresController(IScoresDb scoresDb)
        {
            this.scoresDb = scoresDb;
        }

        // GET: Scores
        public ActionResult Index()
        {
            var scores = this.scoresDb.GetScores();
            scores = scores.OrderByDescending(o => o.studentid).ToList();
            return View(scores);
        }

        // GET: Scores/Details/5
        public ActionResult Details(int id)
        {
            var scores = this.scoresDb.GetScoresModel(id);
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
                this.scoresDb.SaveScores(scoresSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int id)
        {
            var scores = this.scoresDb.GetScoresModel(id);
            return View(scores);
        }

        // POST: Scores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoresUpdateModel scoresUpdate)
        {
            try
            {
                this.scoresDb.UpdateScores(scoresUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
