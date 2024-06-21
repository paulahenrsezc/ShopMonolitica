using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;

namespace ShopMonolitica.Web.Controllers
{
    public class CategoriesController : Controller
    {
    
        public CategoriesController(ICategoriesDb categoriesDb)
        {
            _categoriesDb = categoriesDb;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            var categories = _categoriesDb.GetCategories();
            return View(categories);
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
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

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
