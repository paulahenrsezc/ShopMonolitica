using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using System;

namespace ShopMonolitica.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersService shippersService;

        public ShippersController(IShippersService shippersService)
        {
            this.shippersService = shippersService;
        }

        // GET: ShipperController
        public ActionResult Index()
        {
            var result = shippersService.GetShippers();
            if(!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var shippers = result.Data as List<ShippersModel>;

            return View(shippers);
        }

        // GET: ShipperController/Details/5
        public ActionResult Details(int id)
        {
            var result = shippersService.GetShippersModel(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message; return View();

            }
            var shippers = result.Data as ShippersModel;
            return View(shippers);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShippersSaveModel shippersSaveModel)
        {
            try
            {
                shippersService.SaveShippers(shippersSaveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(shippersSaveModel);
            }
        }

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = shippersService.GetShippersModel(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound();
            }
            var shippers=result.Data as ShippersModel;

            // Mapeo
            var shippersUpdateModel = new ShippersUpdateModel
            {
                shipperid = shippers.shipperid,
                companyname = shippers.companyname,
                phone = shippers.phone

            };

            return View(shippersUpdateModel);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShippersUpdateModel shippersUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(shippersUpdateModel);
            }

            try
            {
                shippersService.UpdateShippers(shippersUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error mientras se actualizaba el shipper. Por favor, intenta nuevamente." + ex);
                return View(shippersUpdateModel);
            }
        }

        /*   // GET: ShipperController/Delete/5
           public ActionResult Delete(int id)
           {
               return View();
           }

           // POST: ShipperController/Delete/5
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
           }*/
    }
}