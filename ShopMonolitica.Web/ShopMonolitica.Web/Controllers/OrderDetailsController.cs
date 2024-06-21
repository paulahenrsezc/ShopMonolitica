using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Employees;
using ShopMonolitica.Web.Data.Models.OrderDetails;

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
            orderdetails = orderdetails.OrderByDescending(e => e.orderid).ToList();
            return View(orderdetails);
        }

        // GET: OrderDetailsController/Details/5
        public ActionResult Details(int id)
        {
            var orderdetails = this.orderdetailsDb.GetOrderDetails(id);
            return View(orderdetails);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetailsSaveModel orderdetailsSave)
        {
            try
            {
                this.orderdetailsDb.SaveOrderDetails(orderdetailsSave);
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
            var orderdetails = this.orderdetailsDb.GetOrderDetails(id);
            return View(orderdetails);
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetailsUpdateModel orderdetailsUpdate)
        {
            try
            {
                this.orderdetailsDb.UpdateOrderDetails(orderdetailsUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderdetailsUpdate);
            }
        }

        // GET: OrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            var orderdetails = this.orderdetailsDb.GetOrderDetails(id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            return View(orderdetails);
        }

        // POST: OrderDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var categoryToRemove = new OrderDetailsRemoveModel
                {
                    orderid = id
                };
                this.orderdetailsDb.RemoveOrderDetails(categoryToRemove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
