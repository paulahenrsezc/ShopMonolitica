using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersDb _usersDb;

        public UsersController(IUsersDb usersDb)
        {
           
           _usersDb = usersDb;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var users = _usersDb.GetUsers();
            users = users.OrderByDescending(c => c.UserId).ToList();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var users = _usersDb.GetUsers(id);
            return View(users);
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
                _usersDb.SaveUser(usersSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var users = _usersDb.GetUsers(id);
            return View(users);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersUpdateModel usersSave)
        {
            try
            {
                _usersDb.UpdateUser(usersSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
        }
    }
}
