using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IEmployeesDb
    {
        void SaveEmployees(EmployeesSaveModel employeesSave);
        void UpdateEmployees(EmployeesUpdateModel employeesUpdate);
        void RemoveEmployees(EmployeesRemoveModel employeesRemove);
        List<EmployeesBaseModel> GetEmployees();
        EmployeesBaseModel GetEmployees(int empid);
    }
}
