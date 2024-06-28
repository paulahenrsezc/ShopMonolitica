using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.BL.Core;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ICustomersService
    {
        ServiceResult GetCustomers();
        ServiceResult GetCustomers(int custid);
        ServiceResult UpdateCustomers(CustomersUpdateModel customersUpdate);
        ServiceResult RemoveCustomers(CustomersRemoveModel customersRemove);
        ServiceResult SaveCustomers(CustomersSaveModel customersSave);


    }
}
