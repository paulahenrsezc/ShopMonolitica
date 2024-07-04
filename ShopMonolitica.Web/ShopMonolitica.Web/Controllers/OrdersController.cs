using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var result = this.ordersService.GetOrders();

            if (!result.Success)
                ViewBag.message = result.Message;

            var orders = (List<OrdersGetModel>)result.Data;
            orders = orders.OrderByDescending(o => o.orderid).ToList();

            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            var result = this.ordersService.GetOrder(id);
            if (!result.Success)
                ViewBag.message = result.Message;

            var orders = (OrdersGetModel)result.Data;
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
                this.ordersService.SaveOrders(ordersSave);
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
            var orders = ordersService.GetOrder(id);
            return View(orders);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersUpdateModel ordersUpdate)
        {
            try
            {
                this.ordersService.UpdateOrders(ordersUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
