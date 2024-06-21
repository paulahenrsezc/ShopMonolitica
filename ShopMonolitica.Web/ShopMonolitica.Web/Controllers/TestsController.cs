using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly ITestsDb testsDb;

        public TestsController(ITestsDb testsDb)
        {
            this.testsDb = testsDb;
        }

        // GET: TestsController1
        public ActionResult Index()
        {
            var tests = this.testsDb.GetTests();
            tests = tests.OrderByDescending(o => o.testid).ToList();
            return View(tests);
        }

        // GET: TestsController1/Details/5
        public ActionResult Details(int id)
        {
            var tests = this.testsDb.GetTestsModel(id);
            return View(tests);
        }

        // GET: TestsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestsSaveModel testsSave)
        {
            try
            {
                this.testsDb.SaveTests(testsSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
