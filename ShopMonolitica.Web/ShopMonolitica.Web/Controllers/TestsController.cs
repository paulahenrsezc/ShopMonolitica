using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Scores;
using ShopMonolitica.Web.Data.Models.Test;

namespace ShopMonolitica.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly ITestsService testsService;

        public TestsController(ITestsService testsService)
        {
            this.testsService = testsService;
        }

        // GET: TestsController1
        public ActionResult Index()
        {
            var result = this.testsService.GetTests();

            if (!result.Success)
                ViewBag.message = result.Message;

            var tests = (List<TestsGetModel>)result.Data;
            tests = tests.OrderByDescending(t => t.testid).ToList();

            return View(tests);
        }

        // GET: TestsController1/Details/5
        public ActionResult Details(string id)
        {
            var result = this.testsService.GetTest(id);
            if (!result.Success)
                ViewBag.message = result.Message;

            var test = (TestsGetModel)result.Data;
            return View(test);
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
                this.testsService.SaveTests(testsSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
