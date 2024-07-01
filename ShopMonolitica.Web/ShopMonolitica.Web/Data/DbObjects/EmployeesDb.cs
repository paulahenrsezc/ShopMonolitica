using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;
using ShopMonolitica.Web.Data.Extentions;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class EmployeesDb : IEmployeesDb
    {
        private readonly ShopContext _shopContext;

        public EmployeesDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<EmployeesBaseModel> GetEmployees()
        {
            return _shopContext.Employees
            .Select(employees => employees.ConvertEmpEntityToEmployeesModel())
            .ToList();
        }

        public EmployeesBaseModel GetEmployees(int empid)
        {
            var employees = _shopContext.Employees.Find(empid).ConvertEmpEntityEmployeesModel();

            if(employees is null)
            {
                throw new EmployeesDbException($"No se pudo encontrar el empleado con el id{empid}");
            }

            return employees;
        }

        public void RemoveEmployees(EmployeesRemoveModel employeesRemove)
        {
            var employee = ValidateEmployeesExists(employeesRemove.empid);
            _shopContext.Employees.Remove(employee);
            _shopContext.SaveChanges();
        }

        public void SaveEmployees(EmployeesSaveModel employeesSave)
        {
            Employees employeesEntity = employeesSave.ConvertEmployeesSaveModelToEmployeesEntity();
            _shopContext.Employees.Add(employeesEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateEmployees(EmployeesUpdateModel employeesUpdate)
        {
            Employees employeesToUpdate = EmployeesGetById(employeesUpdate.empid);

            if (employeesToUpdate != null)
            {
                UpdateEmployeesFields(employeesToUpdate,
                                 employeesUpdate.empid,
                                 employeesUpdate.lastname,
                                 employeesUpdate.firstname,
                                 employeesUpdate.title,
                                 employeesUpdate.titleofcourtesy,
                                 employeesUpdate.birthdate,
                                 employeesUpdate.hiredate,
                                 employeesUpdate.address,
                                 employeesUpdate.city,
                                 employeesUpdate.region,
                                 employeesUpdate.postalcode,
                                 employeesUpdate.country,
                                 employeesUpdate.phone,
                                 employeesUpdate.mgrid);

                _shopContext.SaveChanges();
            }
        }

        private void UpdateEmployeesFields(Employees employeesToUpdate, int empid, string lastname, string firstname, string title, string titleofcourtesy, DateTime birthdate, DateTime hiredate, string address, string city, string? region, string? postalcode, string country, string phone, int? mgrid)
        {
            employeesToUpdate.empid = empid;
            employeesToUpdate.lastname = lastname;
            employeesToUpdate.firstname = firstname;
            employeesToUpdate.title = title;
            employeesToUpdate.titleofcourtesy = titleofcourtesy;
            employeesToUpdate.birthdate = birthdate;
            employeesToUpdate.hiredate = hiredate;
            employeesToUpdate.address = address;
            employeesToUpdate.city = city;
            employeesToUpdate.region = region;
            employeesToUpdate.postalcode = postalcode;
            employeesToUpdate.country = country;
            employeesToUpdate.phone = phone;
            employeesToUpdate.mgrid = mgrid;
        }

        private Employees EmployeesGetById(int empid)
        {
            return _shopContext.Employees.FirstOrDefault(od => od.empid == empid);
        }

        private Employees ValidateEmployeesExists(int empid)
        {
            var employees = _shopContext.Employees.Find(empid);
            return employees;
        }

    }
}
