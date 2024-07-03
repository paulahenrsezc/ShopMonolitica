using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using System.Collections.Generic;
using System.Linq;

namespace ShopMonolitica.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService orderdetailsService;

        public OrderDetailsController(IOrderDetailsService orderdetailsService)
        {
            this.orderdetailsService = orderdetailsService;
        }

        // GET: OrderDetailsController
        public ActionResult Index()
        {
            var serviceResult = this.orderdetailsService.GetOrderDetails();
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var orderdetails = serviceResult.Data as IEnumerable<OrderDetailsBaseModel>;
                    if (orderdetails != null)
                    {
                        var sortedOrderDetails = orderdetails.OrderByDescending(c => c.orderid).ToList();
                        return View(sortedOrderDetails);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Los datos obtenidos no son del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvieron detalles de los pedidos.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
        }

        // GET: OrderDetailsController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.orderdetailsService.GetOrderDetails(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var orderdetail = serviceResult.Data as OrderDetailsBaseModel;
                    if (orderdetail != null)
                    {
                        return View(orderdetail);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el detalle del pedido.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
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
                var serviceResult = this.orderdetailsService.SaveOrderDetails(orderdetailsSave);
                if (serviceResult.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = serviceResult.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.orderdetailsService.GetOrderDetails(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var orderdetail = serviceResult.Data as OrderDetailsBaseModel;
                    if (orderdetail != null)
                    {
                        return View(orderdetail);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el detalle del pedido.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetailsUpdateModel orderdetailsUpdate)
        {
            try
            {
                var serviceResult = this.orderdetailsService.UpdateOrderDetails(orderdetailsUpdate);
                if (serviceResult.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = serviceResult.Message;
                    return View(orderdetailsUpdate);
                }
            }
            catch
            {
                return View(orderdetailsUpdate);
            }
        }

        // GET: OrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            var serviceResult = orderdetailsService.GetOrderDetails(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var orderdetail = serviceResult.Data as OrderDetailsBaseModel;
                    if (orderdetail != null)
                    {
                        return View(orderdetail);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el detalle del pedido.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
        }

        // POST: OrderDetailsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var orderdetailsToRemove = new OrderDetailsRemoveModel
                {
                    orderid = id
                };
                var serviceResult = orderdetailsService.RemoveOrderDetails(orderdetailsToRemove);
                if (serviceResult.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = serviceResult.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
