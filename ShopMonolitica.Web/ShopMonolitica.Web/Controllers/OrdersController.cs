using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersDb ordersDb;

        public OrdersController(IOrdersDb ordersDb)
        {
            this.ordersDb = ordersDb;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = this.ordersDb.GetOrders();
            orders = orders.OrderByDescending(o => o.orderid).ToList();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            var orders = this.ordersDb.GetOrdersModel(id);
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersSaveModel ordersSave)
        {
            try
            {
                this.ordersDb.SaveOrders(ordersSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var orders = ordersDb.GetOrdersModel(id);
            return View(orders);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersUpdateModel ordersUpdate)
        {
            try
            {
                this.ordersDb.UpdateOrders(ordersUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
