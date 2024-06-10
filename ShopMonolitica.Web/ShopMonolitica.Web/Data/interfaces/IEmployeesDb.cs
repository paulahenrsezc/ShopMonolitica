using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IEmployeesDb
    {
        void SaveEmployees(EmployeesSaveModel employeesSave);
        void UpdateEmployees(EmployeesUpdateModel updateModel);
        void RemoveEmployees(EmployeesRemoveModel employeesRemove);
        List<EmployeesModel> GetEmployees();
        EmployeesModel GetEmployees(int idEmployees);
    }
}