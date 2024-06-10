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
        private readonly ShopContext _shopcontext;

        public EmployeesDb(ShopContext context)
        {
            _shopcontext = context;
        }

        public List<EmployeesModel> GetEmployees()
        {
            return _shopcontext.Employees.Select(employees => employees.ConvertEmpEntityToEmployeesModel())
            .ToList();
        }

        public EmployeesModel GetEmployees(int idEmployees)
        {
            var employees = _shopcontext.Employees.Find(idEmployees).ConvertEmpEntityEmployeesModel();
            return employees;
        }

        public void RemoveEmployees(EmployeesRemoveModel employeesRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveEmployees(EmployeesSaveModel employeesSave)
        {
            Employees employeesEntity = employeesSave.ConvertEmployeesSaveModelToEmployeesEntity();
            _shopcontext.Employees.Add(employeesEntity);
            _shopcontext.SaveChanges();
        }

        public void UpdateEmployees(EmployeesUpdateModel updateModel)
        {
            Employees employeesToUpdate = _shopcontext.Employees.Find(updateModel.empid);

            if (employeesToUpdate != null)
            {
                employeesToUpdate.UpdateFromModel(updateModel);
                _shopcontext.Employees.Update(employeesToUpdate);
                _shopcontext.SaveChanges();
            }
        }

    }
}