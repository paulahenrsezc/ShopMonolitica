using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ICustomersDb
    {
        void SaveCustomers(CustomersSaveModel customers);
        void UpdateCustomers(CustomersUpdateModel updateModel);
        void RemoveCustomers(CustomersRemoveModel removeModel);


        List<CustomersModel> GetCustomers();
        CustomersModel GetCustomers(int custid);
    }
}
