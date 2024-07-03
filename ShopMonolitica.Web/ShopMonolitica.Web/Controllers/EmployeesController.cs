using Microsoft.AspNetCore.Mvc;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Employees;
using System.Collections.Generic;
using System.Linq;

namespace ShopMonolitica.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            var serviceResult = this.employeesService.GetEmployees();
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var employees = serviceResult.Data as IEnumerable<EmployeesBaseModel>;
                    if (employees != null)
                    {
                        var sortedEmployees = employees.OrderByDescending(c => c.empid).ToList();
                        return View(sortedEmployees);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Los datos obtenidos no son del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvieron los empleados.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var serviceResult = this.employeesService.GetEmployees(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var employees = serviceResult.Data as EmployeesBaseModel;
                    if (employees != null)
                    {
                        return View(employees);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el empleado.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
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
                var serviceResult = this.employeesService.SaveEmployees(employeesSave);
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceResult = this.employeesService.GetEmployees(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var employees = serviceResult.Data as EmployeesBaseModel;
                    if (employees != null)
                    {
                        return View(employees);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el empleado.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesUpdateModel employeesUpdate)
        {
            try
            {
                var serviceResult = this.employeesService.UpdateEmployees(employeesUpdate);
                if (serviceResult.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = serviceResult.Message;
                    return View(employeesUpdate);
                }
            }
            catch
            {
                return View(employeesUpdate);
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var serviceResult = employeesService.GetEmployees(id);
            if (serviceResult.Success)
            {
                if (serviceResult.Data != null)
                {
                    var employees = serviceResult.Data as EmployeesBaseModel;
                    if (employees != null)
                    {
                        return View(employees);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "El dato obtenido no es del tipo esperado.";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "No se obtuvo el empleado.";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View("Error");
            }
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
                var serviceResult = employeesService.RemoveEmployees(employeesToRemove);
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