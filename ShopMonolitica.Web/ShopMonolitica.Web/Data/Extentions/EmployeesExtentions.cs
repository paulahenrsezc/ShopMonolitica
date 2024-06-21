using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class EmployeesExtentions
    {
        public static EmployeesBaseModel ConvertEmpEntityEmployeesModel(this Employees employees)
        {
            EmployeesBaseModel employeesModel = new EmployeesBaseModel()
            {
                empid = employees.empid,
                lastname = employees.lastname,
                firstname = employees.firstname,
                title = employees.title,
                titleofcourtesy = employees.titleofcourtesy,
                birthdate = employees.birthdate,
                hiredate = employees.hiredate,
                address = employees.address,
                city = employees.city,
                region = employees.region,
                postalcode = employees.postalcode,
                country = employees.country,
                phone = employees.phone,
                mgrid = employees.mgrid
            };

            return employeesModel;
        }

        public static EmployeesBaseModel ConvertEmpEntityToEmployeesModel(this Employees employees)
        {
            return new EmployeesBaseModel
            {
                empid = employees.empid,
                lastname = employees.lastname,
                firstname = employees.firstname,
                title = employees.title,
                titleofcourtesy = employees.titleofcourtesy,
                birthdate = employees.birthdate,
                hiredate = employees.hiredate,
                address = employees.address,
                city = employees.city,
                region = employees.region,
                postalcode = employees.postalcode,
                country = employees.country,
                phone = employees.phone,
                mgrid = employees.mgrid
            };
        }

        public static Employees ConvertEmployeesSaveModelToEmployeesEntity(this EmployeesSaveModel employeesSave)
        {
            return new Employees
            {
                empid = employeesSave.empid,
                lastname = employeesSave.lastname,
                firstname = employeesSave.firstname,
                title = employeesSave.title,
                titleofcourtesy = employeesSave.titleofcourtesy,
                birthdate = employeesSave.birthdate,
                hiredate = employeesSave.hiredate,
                address = employeesSave.address,
                city = employeesSave.city,
                region = employeesSave.region,
                postalcode = employeesSave.postalcode,
                country = employeesSave.country,
                phone = employeesSave.phone,
                mgrid = employeesSave.mgrid
            };
        }

        public static Employees ValidateEmployeesExists(this ShopContext context, int empid)
        {
            var employees = context.Employees.Find(empid);
            if (employees == null)
            {
                throw new EmployeesDbException("El empleado fue encontrado");
            }
            return employees;
        }

        public static void UpdateFromModels(this Employees employees, EmployeesUpdateModel employeesUpdate)
        {
            employeesUpdate.empid = employeesUpdate.empid;
            employeesUpdate.lastname = employeesUpdate.lastname;
            employeesUpdate.firstname = employeesUpdate.firstname;
            employeesUpdate.title = employeesUpdate.title;
            employeesUpdate.titleofcourtesy = employeesUpdate.titleofcourtesy;
            employeesUpdate.birthdate = employeesUpdate.birthdate;
            employeesUpdate.hiredate = employeesUpdate.hiredate;
            employeesUpdate.address = employeesUpdate.address;
            employeesUpdate.city = employeesUpdate.city;
            employeesUpdate.region = employeesUpdate.region;
            employeesUpdate.postalcode = employeesUpdate.postalcode;
            employeesUpdate.country = employeesUpdate.country;
            employeesUpdate.phone = employeesUpdate.phone;
            employeesUpdate.mgrid = employeesUpdate.mgrid;

        }

    }
}
