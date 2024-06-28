using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {

            _customersService = customersService;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            var result = _customersService.GetCustomers();

           if (!result.Success)
                ViewBag.Message = result.Menssage;

            var customers = (List<CustomersModel>)result.Data;
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customersService.GetCustomers(id);

            if (!customer.Success)
            {
                ViewBag.Message = customer.Menssage;
                return View(new CustomersModel());
            }

            return View((CustomersModel)customer.Data);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersSaveModel customersSave)
        {
            try
            {
                ServiceResult result = _customersService.SaveCustomers(customersSave);
                if (!result.Success)
                {
                   
                    ViewBag.ValidationResult = result;
                    return View(customersSave);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(customersSave);
            }
        }

        //GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = _customersService.GetCustomers(id);
            if (serviceResult.Success)
            {
                return View(serviceResult.Data);
            }
            else
            {
                ViewBag.Message = serviceResult.Menssage;
                return View(new ShopMonolitica.Web.Data.Models.CustomersModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersUpdateModel customersModel)
        {
            try
            {
                var result = _customersService.UpdateCustomers(customersModel);

                if (!result.Success)
                {
                    ViewBag.Message = result.Menssage;
                    return View(customersModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(customersModel);
            }
        }


        ////GET: CustomersController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////POST: CustomersController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
