using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ICustomersDb
    {
        void SaveCustomers(CustomersSaveModel customers);
        void UpdateCustomes(CustomerUpdateModel updateModel);
        void RemoveCustomer();


        List<CustomersModel> GetCustomers();
        CustomersModel GetCustomers(int custid);
    }
}
