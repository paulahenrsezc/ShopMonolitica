using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesDb employeesDb;
        public EmployeesController(IEmployeesDb employeesDb)
        {
            this.employeesDb = employeesDb;
        }
        // GET: EmployeesController
        public IActionResult Index()
        {
            var employees = this.employeesDb.GetEmployees();
            employees = employees.OrderByDescending(e => e.empid).ToList();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var employees = this.employeesDb.GetEmployees(id);
            return View(employees);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeesSaveModel employeesSave)
        {
            try
            {
                this.employeesDb.SaveEmployees(employeesSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employees = this.employeesDb.GetEmployees(id);
            return View(employees);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesUpdateModel employeesUpdate)
        {
            try
            {
                this.employeesDb.UpdateEmployees(employeesUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View(employeesUpdate);
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var employees = employeesDb.GetEmployees(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var employeesToRemove = new EmployeesRemoveModel
                {
                    empid = id
                };
                employeesDb.RemoveEmployees(employeesToRemove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
