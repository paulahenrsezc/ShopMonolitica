using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface ICustomersService
    {
        void SaveCustomers(CustomersSaveModel customers);
        void UpdateCustomers(CustomersUpdateModel updateModel);
        void GetCustomers(int custid);
        void RemoveCustomers(CustomersRemoveModel removeModel); 
        List<CustomersModel> GetCustomers();
    }
}
