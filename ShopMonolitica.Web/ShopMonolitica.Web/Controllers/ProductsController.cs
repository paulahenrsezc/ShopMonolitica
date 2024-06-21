using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.ProductModel;

namespace ShopMonolitica.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts productsDb;

        public ProductsController(IProducts productsDb)
        {
            this.productsDb = productsDb;
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            var products = this.productsDb.GetProducts();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = this.productsDb.GetProduct(id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSaveModel productSaveModel)
        {
            try
            {

                productSaveModel.creation_date = DateTime.Now;
                productSaveModel.creation_user = 1;



                // Validar que categoryid no sea null
                if (productSaveModel.categoryid == 0)
                {
                    ModelState.AddModelError("categoryid", "El campo 'categoryid' no puede ser nulo.");
                    ViewBag.Categories = new SelectList(this.productsDb.GetProducts(), "categoryid", "categoryname");
                    return View(productSaveModel);
                   
                }
                this.productsDb.SaveProducts(productSaveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = this.productsDb.GetProduct(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductUpdateModel productUpdateModel)
        {
            try
            {
                productUpdateModel.creation_date = DateTime.Now;
                productUpdateModel.creation_user = 1;

                this.productsDb.UpdateProducts(productUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        
    
    }
}
