using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.BL.Services;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {

            _usersService = usersService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var result = _usersService.GetUsers();

            if (!result.Success)
                ViewBag.Message = result.Menssage;

            var users = (List<UsersModel>)result.Data;
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var users = _usersService.GetUsers(id);

            if (!users.Success)
            {
                ViewBag.Message = users.Menssage;
                return View(new UsersModel());
            }

            return View((UsersModel)users.Data);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersSaveModel usersSave)
        {
            try
            {
                ServiceResult result = _usersService.SaveUsers(usersSave);
                if (!result.Success)
                {

                    ViewBag.ValidationResult = result;
                    return View(usersSave);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(usersSave);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = _usersService.GetUsers(id);
            if (serviceResult.Success)
            {
                return View(serviceResult.Data);
            }
            else
            {
                ViewBag.Message = serviceResult.Menssage;
                return View(new ShopMonolitica.Web.Data.Models.UsersModel());
            }
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersUpdateModel usersSave)
        {
            try
            {
                var result = _usersService.UpdateUsers(usersSave);

                if (!result.Success)
                {
                    ViewBag.Message = result.Menssage;
                    return View(usersSave);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(usersSave);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var serviceResult = _usersService.GetUsers(id);
            if (serviceResult.Success)
            {
                return View(serviceResult.Data);
            }
            else
            {
                ViewBag.Message = serviceResult.Menssage;
                return View(new ShopMonolitica.Web.Data.Models.UsersRemoveModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsersRemoveModel usersRemove)
        {
            try
            {
                var result = _usersService.RemoveUsers(usersRemove);
                if (!result.Success)
                {
                    ViewBag.Message = result.Menssage;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
