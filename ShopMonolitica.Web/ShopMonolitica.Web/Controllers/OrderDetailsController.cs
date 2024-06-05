using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;

namespace ShopMonolitica.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsDb orderdetailsDb;
        public OrderDetailsController(IOrderDetailsDb orderdetailsDb)
        {
            this.orderdetailsDb = orderdetailsDb;
        }
        // GET: OrderDetailsController
        public ActionResult Index()
        {
            var orderdetails = this.orderdetailsDb.GetOrderDetails();
            return View(orderdetails);
        }

        // GET: OrderDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
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

        // GET: OrderDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetailsController/Edit/5
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

        // GET: OrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetailsController/Delete/5
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
