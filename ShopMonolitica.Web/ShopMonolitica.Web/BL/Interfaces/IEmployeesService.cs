using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.BL.Core
{
    public interface IEmployeesService
    {
        ServiceResult GetEmployees();
        ServiceResult GetEmployees(int id);
        ServiceResult UpdateEmployees(EmployeesUpdateModel employeesUpdate);
        ServiceResult RemoveEmployees(EmployeesRemoveModel employeesRemove);
        ServiceResult SaveEmployees(EmployeesSaveModel employeesSave);

    }
}
