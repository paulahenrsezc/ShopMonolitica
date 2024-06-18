using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersDb _customersDb;

        public CustomersController(ICustomersDb customersDb)
        {

            _customersDb = customersDb;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = _customersDb.GetCustomers();
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customers = _customersDb.GetCustomers(id);
            return View(customers);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersSaveModel customersSave)
        {
            try
            {
                _customersDb.SaveCustomers(customersSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customers = _customersDb.GetCustomers(id);
            return View(customers);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersUpdateModel customersUpdate)
        {
            try
            {
                _customersDb.UpdateCustomers(customersUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
