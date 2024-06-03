using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IEmployeesDb
    {
        void Save(Employees employees);
        void UpdateDepartment(Employees employees);
    }
}
