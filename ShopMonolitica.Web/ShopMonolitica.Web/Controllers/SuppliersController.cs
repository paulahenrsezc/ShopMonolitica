
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.SupplierModelos;

namespace ShopMonolitica.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliers suppliersDb;

        public SuppliersController(ISuppliers suppliersDb)
        {
            this.suppliersDb = suppliersDb;
        }
        // GET: SuppliersController
        public ActionResult Index()
        {
            var Suppliers = this.suppliersDb.GetSuppliers();
            Suppliers = Suppliers.OrderByDescending(c => c.supplierid).ToList();

            return View(Suppliers);
            
            }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            var Supplier = this.suppliersDb.GetSupplier(id);
            return View(Supplier);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierSaveModel supplierSaveModel)
        {
            try
            {   supplierSaveModel.creation_date = DateTime.Now;
                supplierSaveModel.creation_user = 1;

                this.suppliersDb.SaveSuppliers(supplierSaveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
            var Supplier = this.suppliersDb.GetSupplier(id);
            return View(Supplier);
            
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierUpdateModel supplierUpdateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(supplierUpdateModel);   
                }

                supplierUpdateModel.creation_date = DateTime.Now;
                supplierUpdateModel.creation_user = 1;

                this.suppliersDb.UpdatesSuppliers(supplierUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
