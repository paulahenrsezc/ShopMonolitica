using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class EmployeesExtentions
    {
        public static EmployeesModel ConvertEmpEntityEmployeesModel(this Employees employees)
        {
            EmployeesModel employeesModel = new EmployeesModel()
            {
                address = employees.address,
                birthdate = employees.birthdate,
                city = employees.city,
                country = employees.country,
                empid = employees.empid,
                firstname = employees.firstname,
                hiredate = employees.hiredate,
                lastname = employees.lastname,
                phone = employees.phone,
                postalcode = employees.postalcode,
                region = employees.region,
                title = employees.title
            };

            return employeesModel;
        }

        public static EmployeesModel ConvertEmpEntityToEmployeesModel(this Employees employees)
        {
            return new EmployeesModel
            {
                address = employees.address,
                birthdate = employees.birthdate,
                city = employees.city,
                country = employees.country,
                empid = employees.empid,
                firstname = employees.firstname,
                hiredate = employees.hiredate,
                lastname = employees.lastname,
                phone = employees.phone,
                postalcode = employees.postalcode,
                region = employees.region,
                title = employees.title
            };
        }

        public static Employees ConvertEmployeesSaveModelToEmployeesEntity(this EmployeesSaveModel employeesSave)
        {
            return new Employees
            {
                address = employeesSave.address,
                birthdate = employeesSave.birthdate,
                city = employeesSave.city,
                country = employeesSave.country,
                empid = employeesSave.empid,
                firstname = employeesSave.firstname,
                hiredate = employeesSave.hiredate,
                lastname = employeesSave.lastname,
                phone = employeesSave.phone,
                postalcode = employeesSave.postalcode,
                region = employeesSave.region,
                title = employeesSave.title
            };
        }

        public static void UpdateFromModel(this Employees employees, EmployeesUpdateModel updateModel)
        {
            employees.modify_date = employees.modify_date;
            employees.modify_user = employees.modify_user;
            employees.address = employees.address;
            employees.birthdate = employees.birthdate;
            employees.city = employees.city;
            employees.country = employees.country;
            employees.firstname = employees.firstname;
            employees.lastname = employees.lastname;
            employees.phone = employees.phone;
            employees.title = employees.title;

        }

    }
}
