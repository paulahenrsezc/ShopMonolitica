using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using System;

namespace ShopMonolitica.Web.Controllers
{
    /// <summary>
    /// Controller de la tabla Categories
    /// </summary>
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        /// <summary>
        /// GET: CategorieController 
        // Creacion de view para obtener la lista de categories
        /// </summary>

        public ActionResult Index()
        {
            var result = categoriesService.GetCategories();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(); 
            }

            var categories = result.Data as List<CategoriesModel>;
            return View(categories);
        }

        /// <summary>
        /// GET: CategorieController/Details/5
        // Creacion de view details, para mostrar detalles de una categoria en especifico
        /// </summary>

        public ActionResult Details(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var category = result.Data as CategoriesModel;
            return View(category); 
        }

        /// <summary>
        /// GET: CategorieController/Create 
        /// Metodo GET: En este caso envia el formulario vacio de los datos de categories
        /// </summary>

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: CategorieController/Create
        /// Metodo POST: En este se procesan y validan los datos para enviarlos a la database
        /// </summary>>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesSaveModel categoriesSaveModel)
        {
            try
            {
                categoriesSaveModel.creation_date = DateTime.Now;
                categoriesSaveModel.creation_user = 2;
                this.categoriesService.SaveCategories(categoriesSaveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound();
            }

            var category = result.Data as CategoriesModel;
            var categoryUpdateModel = new CategoriesUpdateModel
            {
                categoryid = category.categoryid,
                categoryname = category.categoryname,
                description = category.description,
                modify_date = category.creation_date,
                modify_user = category.creation_user
            };

            return View(categoryUpdateModel);
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesUpdateModel categoriesUpdateModel)
        {

            if (!ModelState.IsValid) //Utilizado para validar datos
            {
                return View(categoriesUpdateModel);
            }

            try
            {
                categoriesUpdateModel.modify_date = DateTime.Now;
                categoriesUpdateModel.modify_user = GetCurrentUserId();
                this.categoriesService.UpdateCategories(categoriesUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de ex
                ModelState.AddModelError("", "Ocurrió un error mientras se actualizaba la categoría. Por favor, intenta nuevamente." + ex);
                return View(categoriesUpdateModel);
            }
        }
        //Metodo que envia el id del usuario que realiza algun proceso (edita, crea o elimina en este caso)
        private int GetCurrentUserId()
        {

            return 1; //el usuario registrado en este caso es el user 1
        }


        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound();
            }

            var category = result.Data as CategoriesModel;
            var categoryRemoveModel = new CategoriesRemoveModel
            {
                categoryid = category.categoryid,
                categoryname = category.categoryname,
                description = category.description,
            };

            return View(categoryRemoveModel);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriesRemoveModel categoriesRemoveModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriesRemoveModel);
            }

            try
            {
                categoriesRemoveModel.deleted = true;
                categoriesRemoveModel.delete_date = DateTime.Now;
                categoriesRemoveModel.delete_user = GetCurrentUserId();
                this.categoriesService.RemoveCategories(categoriesRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }

}

