using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ICustomersService
    {

        List<CustomersModel> GetCustomers();
    }
}
