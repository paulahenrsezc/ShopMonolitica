using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopMonolitica.Web.Controllers
{
    public class TestsController : Controller
    {
        // GET: TestsController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
