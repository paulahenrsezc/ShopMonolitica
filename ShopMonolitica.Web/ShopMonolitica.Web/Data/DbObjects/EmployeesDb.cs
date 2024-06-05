using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class EmployeesDb : IEmployeesDb
    {
        private readonly ShopContext context;

        public EmployeesDb(ShopContext context)
        {
            this.context = context;
        }

        public EmployeesModel GetEmployees(int idEmployees)
        {
            var employees = this.context.Employees.Find(idEmployees);

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

        public List<EmployeesModel> GetEmployees()
        {
            return this.context.Employees.Select(employees => new EmployeesModel() 
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
            }).ToList();
        }

        public void SaveEmployees(EmployeesSaveModel employeesSave)
        {

            Employees employees = new Employees() 
            {
                address = employeesSave.address,
                birthdate = employeesSave.birthdate,
                city = employeesSave.city,
                country = employeesSave.country,
                firstname = employeesSave.firstname,
                hiredate = employeesSave.hiredate,
                lastname = employeesSave.lastname,
                phone = employeesSave.phone,
                postalcode = employeesSave.postalcode,
                region = employeesSave.region,
                title = employeesSave.title, 
                creation_user = employeesSave.creation_user
            };
            this.context.Employees.Add(employees);
            this.context.SaveChanges();
        }

        public void UpdateEmployees(EmployeesUpdateModel updateModel)
        {
            Employees employeesToUpdate = this.context.Employees.Find(updateModel.empid);

            if(employeesToUpdate is null)
            {
                throw new EmployeesDbException("El empleado no se encuentra registrado.");
            }

            employeesToUpdate.modify_date = updateModel.modify_date;
            employeesToUpdate.modify_user = updateModel.modify_user;
            employeesToUpdate.address = updateModel.address;
            employeesToUpdate.birthdate = updateModel.birthdate;
            employeesToUpdate.city = updateModel.city;
            employeesToUpdate.country = updateModel.country;
            employeesToUpdate.firstname = updateModel.firstname;
            employeesToUpdate.lastname = updateModel.lastname;
            employeesToUpdate.phone = updateModel.phone;
            employeesToUpdate.title = updateModel.title;

            this.context.Employees.Update(employeesToUpdate);
            this.context.SaveChanges();
        }

        public void RemoveEmployees(EmployeesRemoveModel employeesRemove)
        {
            Employees employeesToDelete = this.context.Employees.Find(employeesRemove.empid);

            if(employeesToDelete is null)
            {
                throw new EmployeesDbException("El empleado no se encuentra registrado.");
            }

            employeesToDelete.deleted = employeesRemove.deleted;
            employeesToDelete.delete_date = employeesRemove.delete_date;
            employeesToDelete.delete_user = employeesRemove.delete_user;

            this.context.Employees.Update(employeesToDelete);

            this.context.SaveChanges();

        }
    }
}
